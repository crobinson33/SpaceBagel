using System;

namespace SpaceBagel
{
	public class BaseDrawable
	{

		public float Width;
		public float Height;

		public BaseDrawable ()
		{
		}

		public virtual void Render(float x, float y)
		{
		}
	}
}

