using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class Surface
    {
        internal SFML.Graphics.RenderTexture target;
        internal SFML.Graphics.Sprite sprite;
        internal SFML.Graphics.RenderWindow window;
        internal SFML.Graphics.RenderStates renderStates;
        public Color baseColor;

        public Surface(uint width, uint height, Color color, SFML.Graphics.RenderWindow window)
        {
            target = new SFML.Graphics.RenderTexture((uint) width, (uint) height);
            baseColor = color;
            sprite = new SFML.Graphics.Sprite(target.Texture);
            this.window = window;
        }

        public void DrawToWindow()
        {
            window.Draw(sprite);
        }

        public void Clear()
        {
            target.Clear(baseColor.SFMLColor);
        }

        public void Draw(Sprite drawable)
        {
            target.Draw(drawable.sprite);
            target.Display();
        }

    }
}
