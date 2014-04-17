using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
	public class Light
	{
        public Vector2 position;
        public Color color;
        public float intensity;
        public Shader shader;
        internal SFML.Graphics.RenderStates renderStates;

        /// <summary>
        /// override this with game logic
        /// </summary>
        public virtual void Update(float deltaTime)
        {
            
        }

        public virtual void Draw(Surface surface, float deltaTime)
        {

        }

        public void AddShader(Shader shader)
        {
            this.renderStates.Shader = shader.SFMLshader;
        }
	}
}

