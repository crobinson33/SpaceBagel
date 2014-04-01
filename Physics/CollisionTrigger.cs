using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    /// <summary>
    /// Holds all info for collision triggers
    /// </summary>
    public class CollisionTrigger
    {
        public Collider collider;
        public Action method;

        /// <summary>
        /// Takes in the collider to check against and the method to call when collision.
        /// </summary>
        /// <param name="collider">Collider</param>
        /// <param name="method">Action</param>
        public CollisionTrigger(Collider collider, Action method)
        {
            this.collider = collider;
            this.method = method;
        }
    }
}
