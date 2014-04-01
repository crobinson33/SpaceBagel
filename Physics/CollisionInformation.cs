using System;

namespace SpaceBagel
{
	/// <summary>
	/// Needed to hold the info about collisions for the CollisionResolution object.
	/// </summary>
	public class CollisionInformation
	{
		public Collider object1;
		public Collider object2;
		public Collider objectOne { get; set; }
		public Collider objectTwo { get; set; }

		public float penetrationAmount { get; set; }

		public Vector2 collisionNormal { get; set; }

		public CollisionInformation()
		{
		}

		public CollisionInformation(Collider objectOne, Collider objectTwo, float penetrationAmount, Vector2 collisionNormal)
		{
			this.objectOne = objectOne;
			this.objectTwo = objectTwo;
			this.penetrationAmount = penetrationAmount;
			this.collisionNormal = collisionNormal;
		}
	}
}

