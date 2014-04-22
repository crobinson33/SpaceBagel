using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public Texture texture;

        public Surface(uint width, uint height)
        {
            target = new SFML.Graphics.RenderTexture((uint) width, (uint) height);
            texture = new Texture((int)target.Size.X, (int)target.Size.Y);
            renderStates = SFML.Graphics.RenderStates.Default;
            vertexArray = new SFML.Graphics.VertexArray(SFML.Graphics.PrimitiveType.Quads, 0);
            vertexArray.Append(new Vertex(new Vector2(0, 0), new Vector2(0, 0)).SFMLVertex);
            vertexArray.Append(new Vertex(new Vector2(target.Size.X, 0), new Vector2(target.Size.X, 0)).SFMLVertex);
            vertexArray.Append(new Vertex(new Vector2(target.Size.X, target.Size.Y), new Vector2(target.Size.X, target.Size.Y)).SFMLVertex);
            vertexArray.Append(new Vertex(new Vector2(0, target.Size.Y), new Vector2(0, target.Size.Y)).SFMLVertex);
            texture.source = target.Texture;
            renderStates.Texture = texture.source;
            Console.WriteLine(renderStates.Texture);
        }

        public void AddShader(Shader shader)
        {
            this.renderStates.Shader = shader.SFMLshader;
        }

        // Draws surface to window
        public void DrawToWindow(SFML.Graphics.RenderWindow window)
        {
            window.Draw(vertexArray, renderStates);
            
            window.Display();
        }

        // Clears entire frame / begins frame
        public void Clear()
        {
            target.Clear(Color.Transparent.SFMLColor);
        }

        public void Clear(Color color)
        {
            target.Clear(color.SFMLColor);
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

        public void Draw(Spotlight sLight, Vector2 position, float deltaTime)
        {
            sLight.Update(position, deltaTime);
            target.Draw(sLight.array, sLight.renderStates);
        }

        public void Draw(Collider collider, Vector2 position, float deltaTime)
        {
            target.Draw(collider.debugDraw);
        }

        public void Draw(Surface surface, float deltaTime)
        {
            target.Draw(surface.vertexArray, surface.renderStates);
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
