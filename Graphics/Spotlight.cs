using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class Spotlight : Light
    {
        internal SFML.Graphics.CircleShape circleShape;
        public Spotlight (int radius, Color color, Vector2 position, float intensity)
		{
            circleShape = new SFML.Graphics.CircleShape(radius, 100);
            this.color = color;
            circleShape.FillColor = this.color.SFMLColor;
            this.position = position;
            circleShape.Position = this.position.SFMLVector2;
            renderStates = SFML.Graphics.RenderStates.Default;
            renderStates.BlendMode = SFML.Graphics.BlendMode.Add;
            shader = new Shader(null, "shaders/calcLightIntensity.frag");
            this.AddShader(shader);
            this.intensity = intensity;
		}

        /// <summary>
        /// override this with game logic
        /// </summary>
        public override void Update(float deltaTime)
        {
            
        }

        public override void Draw(Surface surface, float deltaTime)
        {
            surface.Draw(this, position, deltaTime);
        }
    }
}
