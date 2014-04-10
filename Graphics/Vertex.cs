using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    /// <summary>
    /// Wrapper for SFML Vertex
    /// </summary>
    public class Vertex
    {
        public Vector2 position;
        public Color color;
        public Vector2 texCoords;

        /// <summary>
        /// Access SFML Vertex directly
        /// </summary>
        internal SFML.Graphics.Vertex SFMLVertex
        {
            get { return new SFML.Graphics.Vertex(new SFML.Window.Vector2f(position.X, position.Y), color.SFMLColor, new SFML.Window.Vector2f(texCoords.X, texCoords.Y)); }
        }

        public Vertex(Vector2 position) :
            this(position, Color.White, new Vector2(0, 0))
        {
        }
        public Vertex(Vector2 position, Color color) :
            this(position, color, new Vector2(0, 0))
        {
        }

        public Vertex(Vector2 position, Vector2 texCoords) :
            this(position, Color.White, texCoords)
        {
        }

        public Vertex(Vector2 position, Color color, Vector2 texCoords)
        {
            this.position = position;
            this.color = color;
            this.texCoords = texCoords;
        }

        public override string ToString()
        {
            return "[Vertex]" +
                    " Position(" + position + ")" +
                    " Color(" + color + ")" +
                    " TexCoords(" + texCoords + ")";
        }
    }
}
