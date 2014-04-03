using System;

namespace SpaceBagel
{
	public class Color
	{
		public float r;
		public float g;
		public float b;
		public float a;

		public Color ()
		{
			r = 1.0f;
			g = 1.0f;
			b = 1.0f;
			a = 1.0f;
		}

        public Color(float r, float g, float b, float a)
        {
            this.r = Util.Clamp(r);
            this.g = Util.Clamp(g);
            this.b = Util.Clamp(b);
            this.a = Util.Clamp(a);
        }

        public Color(float R, float G, float B)
        {
            this.r = Util.Clamp(r);
            this.g = Util.Clamp(g);
            this.b = Util.Clamp(b);
            this.a = 1.0f;
        }

        internal SFML.Graphics.Color SFMLColor
        {
            get { return new SFML.Graphics.Color(ByteR, ByteG, ByteB, ByteA); }
        }

        internal Byte ByteR
        {
            get
            {
                float f = r * 255f;
                int i = (int)Math.Round(f);
                return Convert.ToByte(i);
            }
        }

        internal Byte ByteG
        {
            get
            {
                float f = g * 255f;
                int i = (int)Math.Round(f);
                return Convert.ToByte(i);
            }
        }

        internal Byte ByteB
        {
            get
            {
                float f = b * 255f;
                int i = (int)Math.Round(f);
                return Convert.ToByte(i);
            }
        }

        internal Byte ByteA
        {
            get
            {
                float f = a * 255f;
                int i = (int)Math.Round(f);
                return Convert.ToByte(i);
            }
        }
	}
}

