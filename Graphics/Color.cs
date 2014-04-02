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
			R = 1.0f;
			G = 1.0f;
			B = 1.0f;
			A = 1.0f;
		}
	}
}

