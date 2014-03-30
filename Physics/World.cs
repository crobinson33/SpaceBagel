using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	public class World
	{
		public List<Collider> colliders;

		public World ()
		{
			colliders = new List<Collider>();
		}

		/// <summary>
		/// Updates all physic objects
		/// </summary>
		public void Update()
		{
			foreach (Collider collider in colliders)
			{
				collider.OnCollisionEnter(null);
			}
		}

		/// <summary>
		/// Adds the box collider.
		/// </summary>
		/// <param name="boxCollider">Box collider.</param>
		public void AddCollider(BoxCollider boxCollider)
		{
			colliders.Add(boxCollider);
		}

		public void AddCollider(CharacterCollider characterCollider)
		{
			colliders.Add(characterCollider);
		}
	}
}

