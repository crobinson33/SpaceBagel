using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	/// <summary>
	/// Used by world to resolve collision info
	/// </summary>
	public class CollisionResolution
	{
		public CollisionResolution ()
		{
		}

		/// <summary>
		/// Takes all collisions and resolves them. If the object is static its velocity and position are uneffected.
		/// </summary>
		/// <param name="collisions">Collisions.</param>
		public void ResolveAllCollisions(List<CollisionInformation> collisions)
		{
            //Console.WriteLine(collisions.Count);
			// loop through all collisions and resolve!
			foreach(CollisionInformation collision in collisions)
			{
                //Console.WriteLine("loop");
				ResolveBoxCollision(collision);
			}
		}

        public void ResolveCollision(CollisionInformation collision)
        {
            if (collision.collisionNormal.X == -1)
            {
                Console.WriteLine("got here");
                //Console.WriteLine(collision.objectOne.velocity);
                collision.objectTwo.velocity.X *= -1;
            }
        }

		/// <summary>
		/// Takes a specific instance of a collision and resolves it.
		/// </summary>
		/// <param name="collision">Collision.</param>
		public void ResolveBoxCollision(CollisionInformation collision)
		{
            //Console.WriteLine("resolving...");
			// Calculate relative velocity
			Vector2 relativeVelocity = collision.objectTwo.velocity - collision.objectOne.velocity;
            //Console.WriteLine(relativeVelocity);

			// Calculate relative velocity in terms of the normal direction
            Vector2 forDot = new Vector2();
			float velAlongNormal = forDot.Dot(relativeVelocity, collision.collisionNormal);

            float objectOneInvMass = (float)1 / collision.objectOne.mass;
            float objectTwoInvMass = (float)1 / collision.objectTwo.mass;

			// Do not resolve if velocities are separating
			if(velAlongNormal > 0)
			{
				return;
			}

			// Calculate restitution
			float e = Math.Min(collision.objectOne.restitution, collision.objectTwo.restitution);

			// Calculate impulse scalar
			float j = -(1 + e) * velAlongNormal;
            j /= objectOneInvMass + objectTwoInvMass;

			// Apply impulse
			Vector2 impulse = collision.collisionNormal * j;
            //Console.WriteLine(impulse);

            if (collision.objectOne.mass > 0)
            {
                // only resolve if the object is not static.
                if (collision.objectOne.isStatic != true)
                {
                    //Console.WriteLine("applying: -=" + (1 / collision.objectOne.mass * impulse));
                    collision.objectOne.velocity -= (objectOneInvMass * impulse);
                }
            }
            if (collision.objectTwo.mass > 0)
            {
                // only resolve if the object is not static.
                if (collision.objectTwo.isStatic != true)
                {
                    //Console.WriteLine("applying: +=" + (1 / collision.objectTwo.mass * impulse));
                    collision.objectTwo.velocity += (objectTwoInvMass * impulse);
                }
            }

            float percent = 0.1f; // usually 20% to 80%
            float slop = 0.01f; // usually 0.01 to 0.1
            Vector2 correction = Math.Max(collision.penetrationAmount - slop, 0) / (objectOneInvMass + objectTwoInvMass) * percent * collision.collisionNormal;
            //Console.WriteLine(correction);
            if (collision.objectOne.isStatic != true)
            {
                collision.objectOne.position -= objectOneInvMass * correction;
            }
            if (collision.objectTwo.isStatic != true)
            {
                collision.objectTwo.position += objectTwoInvMass * correction;
            }
		}
	}
}

