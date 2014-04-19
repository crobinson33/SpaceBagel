﻿using System;
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
		public int width;
		public int height;
        public int z;
        public Color color;
        public Shader shader;
        public bool selfIlluminated;
        internal SFML.Graphics.RenderStates renderStates;
        internal SFML.Graphics.Sprite drawableSource;

        public void AddShader(Shader shader)
        {
            this.shader = shader;
            this.renderStates.Shader = this.shader.SFMLshader;
        }

        public virtual void Update(Vector2 position, float deltaTime)
        {

        }
    }
}

