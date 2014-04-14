using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    /// <summary>
    /// Surface that can be drawn to, and in turn be drawn to a Window or other Surface
    /// </summary>
    public class Surface
    {
        internal SFML.Graphics.RenderTexture target;
        internal SFML.Graphics.RenderStates renderStates;
        internal SFML.Graphics.VertexArray vertexArray;
        internal SFML.Graphics.Texture t;
        public List<BaseDrawable> drawables = new List<BaseDrawable>();
        public Color baseColor;

        // test
        SFML.Graphics.Sprite sprite;

        public Surface(uint width, uint height, Color color)
        {
            target = new SFML.Graphics.RenderTexture((uint) width, (uint) height);
            baseColor = color;
            renderStates = SFML.Graphics.RenderStates.Default;
            vertexArray = new SFML.Graphics.VertexArray(SFML.Graphics.PrimitiveType.Quads, 0);
            vertexArray.Append(new Vertex(new Vector2(0, 0), new Vector2(0, 0)).SFMLVertex);
            vertexArray.Append(new Vertex(new Vector2(target.Size.X, 0), new Vector2(target.Size.X, 0)).SFMLVertex);
            vertexArray.Append(new Vertex(new Vector2(target.Size.X, target.Size.Y), new Vector2(target.Size.X, target.Size.Y)).SFMLVertex);
            vertexArray.Append(new Vertex(new Vector2(0, target.Size.Y), new Vector2(0, target.Size.Y)).SFMLVertex);
            //sprite = new SFML.Graphics.Sprite(target.Texture);
            t = target.Texture;
            renderStates.Texture = t;
        }

        // Draws surface to window
        public void DrawToWindow(SFML.Graphics.RenderWindow window)
        {
            target.Display();
            window.Draw(vertexArray, renderStates);
            window.Display();
        }

        // Clears entire frame / begins frame
        public void Clear()
        {
            target.Clear(baseColor.SFMLColor);
        }

        // End the current Frame
        public void Display()
        {
            target.Display();
        }

        // Draws sprite to surface
        public void Draw(Sprite sprite, Vector2 position, float deltaTime)
        {
            sprite.Update(position, deltaTime);
            target.Draw(sprite.drawableSource, sprite.renderStates);
        }

        // Draws animated sprite to surface
        public void Draw(AnimatedSprite aSprite, Vector2 position, float deltaTime)
        {
            aSprite.Update(position, deltaTime);
            target.Draw(aSprite.drawableSource, aSprite.renderStates);
        }

        // Draws multi drawable to surface
        public void Draw(MultiDrawable multiDrawable, Vector2 position, float deltaTime)
        {
            multiDrawable.Update(position, deltaTime);
            if (multiDrawable.drawPartsInFront)
            {
                target.Draw(multiDrawable.baseDrawable.drawableSource, multiDrawable.baseDrawable.renderStates);
                foreach (BaseDrawable obj in multiDrawable.drawableParts)
                {
                    target.Draw(obj.drawableSource, obj.renderStates);
                }
            }
            else
            {
                foreach (BaseDrawable obj in multiDrawable.drawableParts)
                {
                    target.Draw(obj.drawableSource, obj.renderStates);
                }
                target.Draw(multiDrawable.baseDrawable.drawableSource, multiDrawable.baseDrawable.renderStates);
            }
        }
    }
}
