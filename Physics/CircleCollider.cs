using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class CircleCollider : Collider
    {
        public float radius;

        public CircleCollider(string tag) : base(tag)
        {
        }

        public CircleCollider(string tag, Vector2 pos, float radius) : base(tag)
        {
            this.position = pos;
            this.radius = radius;
        }
    }
}
