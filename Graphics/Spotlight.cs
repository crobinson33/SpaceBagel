using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class Spotlight : Light
    {
        internal SFML.Graphics.VertexArray array;
        public Spotlight(int radius, Color color, Vector2 position, int points, float intensity)
        {
            this.color = color;
            this.position = position;
            this.array = createArray(points, radius, false);
            renderStates = SFML.Graphics.RenderStates.Default;
            renderStates.BlendMode = SFML.Graphics.BlendMode.Add;
            shader = new Shader(null, "shaders/calcLightIntensity.frag");
            this.AddShader(shader);
            this.intensity = intensity;
        }
        public Spotlight (int radius, Color color, Vector2 position, int points, float intensity, bool attenuate)
		{
            this.color = color;
            this.position = position;
            this.array = createArray(points, radius, attenuate);
            renderStates = SFML.Graphics.RenderStates.Default;
            renderStates.BlendMode = SFML.Graphics.BlendMode.Add;
            shader = new Shader(null, "shaders/calcLightIntensity.frag");
            this.AddShader(shader);
            this.intensity = intensity;
		}

        internal SFML.Graphics.VertexArray createArray(int points, int radius, bool attenuate)
        {
            SFML.Graphics.VertexArray newArray = new SFML.Graphics.VertexArray(SFML.Graphics.PrimitiveType.TrianglesFan);
            float radianStep = ((float)Math.PI * 2f) / points;
            float curRadian = 0;
            float curX = 0;
            float curY = 0;
            newArray.Append(new Vertex(this.position, this.color).SFMLVertex);
            if (!attenuate)
            {
                for (int i = 0; i < points + 1; i++)
                {
                    curX = radius * (float)Math.Cos(curRadian) + this.position.X;
                    curY = radius * (float)Math.Sin(curRadian) + this.position.Y;
                    newArray.Append(new Vertex(new Vector2(curX, curY), this.color).SFMLVertex);
                    curRadian += radianStep;
                }
            }
            else
            {
                for (int i = 0; i < points + 1; i++)
                {
                    curX = radius * (float)Math.Cos(curRadian) + this.position.X;
                    curY = radius * (float)Math.Sin(curRadian) + this.position.Y;
                    newArray.Append(new Vertex(new Vector2(curX, curY), new Color(this.color.r, this.color.g, this.color.b, 0.0f)).SFMLVertex);
                    curRadian += radianStep;
                }
            }
            return newArray;
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
