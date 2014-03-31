using System;

namespace SpaceBagel
{
	public class Sprite
	{
		internal SFML.Graphics.Sprite sprite;
		internal AnimationController animationController = new AnimationController();

		/// <summary>
		/// Creates a new sprite from the given texture.
		/// </summary>
		/// <param name="texture">Texture to use.</param>
		public Sprite (Texture texture)
		{
			sprite = new SFML.Graphics.Sprite (texture.texture);
		}

		public void setColor()
		{
		}

	}
}

