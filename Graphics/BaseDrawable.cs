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
		public int width;
		public int height;
        public int z;

        // distance down from position to use for y sorting of drawables
        public int yRenderOffset;

        public Color color;
        public Shader shader;
        public Shader selfIlluminateShader;
        internal SFML.Graphics.RenderStates renderStates;
        internal SFML.Graphics.Sprite drawableSource;

        public void AddShader(Shader shader)
        {
            this.shader = shader;
            this.renderStates.Shader = this.shader.SFMLshader;
        }

        public void RemoveShader()
        {
            this.shader = null;
            this.renderStates.Shader = null;
        }

        public virtual void Update(Vector2 position, float deltaTime)
        {

        }
    }
}

