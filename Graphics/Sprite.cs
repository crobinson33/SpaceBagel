using System;

namespace SpaceBagel
{
	public class Sprite
	{
		internal SFML.Graphics.Sprite sprite;
        internal SFML.Graphics.RenderWindow renderWindow;
        internal SFML.Graphics.RenderStates renderStates;
        public Color color;

        public Sprite()
        {

        }

		/// <summary>
		/// Creates a new sprite from the given texture.
		/// </summary>
		/// <param name="texture">Texture to use.</param>
		public Sprite (Texture texture)
		{
			sprite = new SFML.Graphics.Sprite (texture.texture);
            Console.WriteLine(sprite = new SFML.Graphics.Sprite (texture.texture));
		}

		public void Draw (SFML.Graphics.RenderTarget window, SFML.Graphics.RenderStates renderStates, Vector2 position)
		{
            sprite.Draw(window, renderStates);
		}

		public void setColor(Color color)
		{
			this.color = color;
		}
	}
}

