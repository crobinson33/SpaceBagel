using System;

namespace SpaceBagel
{
	public class Sprite : BaseDrawable
	{
		internal SFML.Graphics.Sprite sprite;

		/// <summary>
		/// Creates a new sprite from the given texture.
		/// </summary>
		/// <param name="texture">Texture to use.</param>
		public Sprite (Texture texture)
		{
			sprite = new SFML.Graphics.Sprite (texture.texture);
		}

		public override void Render (float x, float y)
		{

		}

		public void setColor(Color color)
		{
			sprite.Color = color;
		}
	}
}

