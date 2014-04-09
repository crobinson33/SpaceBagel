using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    /// <summary>
    /// A class to define base attributes af all drawables.
    /// </summary>
	public class BaseDrawable
	{
		public uint width;
		public uint height;
        public Color color;
        public Shader shader;
        internal SFML.Graphics.RenderStates renderStates;
	}
}

