using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	public class World
	{
		// holds the list of colliders.
		public List<Collider> colliders;
        public List<CollisionInformation> collisions;

        // do the checks.
        public CollisionDetector detector;
        // resolve all collisions
        public CollisionResolution resolution;

		/// <summary>
		/// Default constructor
		/// </summary>
		public World ()
		{
			colliders = new List<Collider>();
            collisions = new List<CollisionInformation>();
            detector = new CollisionDetector();
            resolution = new CollisionResolution();
            //Console.WriteLine("whats the order");
		}

		/// <summary>
		/// Updates all physics objects
		/// </summary>
		public void Update(float deltaTime)
		{
            collisions = detector.GetAllCollisions(colliders);
            resolution.ResolveAllCollisions(collisions);
            //Console.WriteLine(colliders[0].velocity);

            foreach (Collider collider in colliders)
            {
                collider.CalculatePoints();
                collider.Update(deltaTime);
            }
		}

		/// <summary>
		/// Adds the collider.
		/// </summary>
		/// <param name="boxCollider">Box collider.</param>
		public void AddCollider(Collider collider)
		{
			colliders.Add(collider);
            //Console.WriteLine("added: " + collider.velocity);
		}

        public void RemoveCollider(Collider collider)
        {
            colliders.Remove(collider);
        }

	}
}

