using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class Quad
    {
        public List<Vector2> vertices;

        public Quad()
        {
            vertices = new List<Vector2>();
            vertices.Add(new Vector2(0, 0));
            vertices.Add(new Vector2(0, 0));
            vertices.Add(new Vector2(0, 0));
            vertices.Add(new Vector2(0, 0));
        }

        public Quad(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3, Vector2 vertex4)
        {
            vertices = new List<Vector2>();
            vertices.Add(vertex1);
            vertices.Add(vertex2);
            vertices.Add(vertex3);
            vertices.Add(vertex4);
        }

        public Vector2 TopLeft
        {
            get { return vertices[0]; }
            set { vertices[0] = value; }
        }

        public Vector2 TopRight
        {
            get { return vertices[1]; }
            set { vertices[1] = value; }
        }

        public Vector2 BottomRight
        {
            get { return vertices[2]; }
            set { vertices[2] = value; }
        }

        public Vector2 BottomLeft
        {
            get { return vertices[3]; }
            set { vertices[3] = value; }
        }
    }
}
