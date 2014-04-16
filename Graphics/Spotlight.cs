using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class Spotlight : Light
    {
        internal SFML.Graphics.CircleShape circleShape;
        public Spotlight (int radius, Color color, Vector2 position)
		{
            circleShape = new SFML.Graphics.CircleShape(radius, 100);
            circleShape.FillColor = color.SFMLColor;
            this.position = position;
            circleShape.Position = this.position.SFMLVector2;
            renderStates = SFML.Graphics.RenderStates.Default;
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
