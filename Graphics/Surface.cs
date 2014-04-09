using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class Surface
    {
        internal SFML.Graphics.RenderTexture target;
        internal SFML.Graphics.RenderStates renderStates;
        internal SFML.Graphics.VertexArray vertexArray;
        internal SFML.Graphics.Texture t;
        public BaseDrawable[] drawables;
        public Color baseColor;

        // test
        SFML.Graphics.Sprite sprite;

        public Surface(uint width, uint height, Color color)
        {
            target = new SFML.Graphics.RenderTexture((uint) width, (uint) height);
            baseColor = color;
            this.renderStates = SFML.Graphics.RenderStates.Default;
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

        // Draws layer to surface
        public void Draw(Sprite sprite, Vector2 position)
        {
            sprite.drawableSource.Position = position.SFMLVector2;
            target.Draw(sprite.drawableSource);
        }
    }
}
