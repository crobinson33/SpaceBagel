using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	public class World
	{
		// holds the list of colliders.
		public List<Collider> colliders;

        // do the checks.
        public CollisionDetector detector;

		/// <summary>
		/// Default constructor
		/// </summary>
		public World ()
		{
			colliders = new List<Collider>();
            detector = new CollisionDetector();
		}

		/// <summary>
		/// Updates all physics objects
		/// </summary>
		public void Update()
		{
            detector.GetAllCollisions(colliders);
		}

		/// <summary>
		/// Adds the box collider.
		/// </summary>
		/// <param name="boxCollider">Box collider.</param>
		public void AddCollider(BoxCollider boxCollider)
		{
			colliders.Add(boxCollider);
		}

		/// <summary>
		/// Adds the character collider.
		/// </summary>
		/// <param name="characterCollider">Character collider.</param>
		public void AddCollider(CharacterCollider characterCollider)
		{
			colliders.Add(characterCollider);
		}
	}
}

