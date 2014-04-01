using System;

namespace SpaceBagel
{
	public class Color
	{
		internal SFML.Graphics.Color color;
		public float R;
		public float G;
		public float B;
		public float A;

		public Color ()
		{
			color.R = 1.0f;
			color.G = 1.0f;
			color.B = 1.0f;
			color.A = 1.0f;
		}
	}
}

