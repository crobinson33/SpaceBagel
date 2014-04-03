using System;

namespace SpaceBagel
{
	public class Sprite : BaseDrawable
	{
		internal SFML.Graphics.Sprite sprite;

        public Sprite()
        {

        }

		public Sprite (Texture texture)
		{
			sprite = new SFML.Graphics.Sprite (texture.texture);
            drawableSource = sprite;
            renderStates = new SFML.Graphics.RenderStates();
		}

		public void setColor(Color color)
		{
			this.color = color;
		}

        public override void Draw(SFML.Graphics.RenderTarget target, SFML.Graphics.RenderStates renderStates)
        {
            sprite.Draw(target, renderStates);
        }
	}
}

