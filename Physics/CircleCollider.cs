using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    /// <summary>
    /// Creates 2d circle colliders.
    /// </summary>
    public class CircleCollider : Collider
    {

        public CircleCollider(string tag) : base(tag)
        {
        }

        public CircleCollider(string tag, Vector2 pos, float radius) : base(tag)
        {
            this.position = pos;
            this.radius = radius;
        }

        /// <summary>
        /// Is triggered when this collider comes into contact with given collider
        /// </summary>
        /// <param name="collider">Collider.</param>
        public override void CreateOnCollisionEnter(Collider collider, Action method)
        {
            CollisionTrigger newTrigger = new CollisionTrigger(collider, method);
            triggers.Add(newTrigger);
        }
    }
}
