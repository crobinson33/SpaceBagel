using System;

namespace SpaceBagel
{
	public class BaseDrawable
	{

		public float Width;
		public float Height;
        public Color color;

		public BaseDrawable ()
		{
		}

		public virtual void Render(Vector2 position)
		{

		}
	}
}

