using System;

namespace SpaceBagel
{
	public class BaseDrawable
	{

		public float width;
		public float height;
        public Color color;
        public Shader shader;
        internal SFML.Graphics.Drawable drawableSource;
        internal SFML.Graphics.RenderStates renderStates;

		public BaseDrawable ()
		{
		}

		public virtual void Draw(SFML.Graphics.RenderTarget target, SFML.Graphics.RenderStates renderStates)
		{

		}
	}
}

