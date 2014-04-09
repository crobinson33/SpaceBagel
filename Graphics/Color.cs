using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
			r = 1f;
			g = 1f;
			b = 1f;
			a = 1f;
		}

        public Color(float r, float g, float b, float a)
        {
            this.r = Util.Clamp(r);
            this.g = Util.Clamp(g);
            this.b = Util.Clamp(b);
            this.a = Util.Clamp(a);
        }

        public Color(float r, float g, float b)
        {
            this.r = Util.Clamp(r);
            this.g = Util.Clamp(g);
            this.b = Util.Clamp(b);
            this.a = 1f;
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

        /// <summary>Predefined black color</summary>
        public static readonly Color Black = new Color(0f, 0f, 0f);

        /// <summary>Predefined white color</summary>
        public static readonly Color White = new Color(1f, 1f, 1f);

        /// <summary>Predefined red color</summary>
        public static readonly Color Red = new Color(1f, 0f, 0f);

        /// <summary>Predefined green color</summary>
        public static readonly Color Green = new Color(0f, 1f, 0f);

        /// <summary>Predefined blue color</summary>
        public static readonly Color Blue = new Color(0f, 0f, 1f);

        /// <summary>Predefined yellow color</summary>
        public static readonly Color Yellow = new Color(1f, 1f, 0f);

        /// <summary>Predefined magenta color</summary>
        public static readonly Color Magenta = new Color(1f, 0f, 1f);

        /// <summary>Predefined cyan color</summary>
        public static readonly Color Cyan = new Color(0f, 1f, 1f);

        /// <summary>Predefined (black) transparent color</summary>
        public static readonly Color Transparent = new Color(0f, 0f, 0f, 0f);

        public override string ToString()
        {
            return "[Color]" +
                   " R(" + r + ")" +
                   " G(" + g + ")" +
                   " B(" + b + ")" +
                   " A(" + a + ")";
        }
	}
}

