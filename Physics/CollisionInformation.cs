using System;

namespace SpaceBagel
{
	/// <summary>
	/// Needed to hold the info about collisions for the CollisionResolution object.
	/// </summary>
	public class CollisionInformation
	{
		public Collider objectOne { get; set; }
		public Collider objectTwo { get; set; }

		public float penetrationAmount { get; set; }

		public Vector2 collisionNormal { get; set; }

        public string collisionType { get; set; }

		public CollisionInformation()
		{
		}

		public CollisionInformation(Collider objectOne, Collider objectTwo, float penetrationAmount, Vector2 collisionNormal, string type)
		{
			this.objectOne = objectOne;
			this.objectTwo = objectTwo;
			this.penetrationAmount = penetrationAmount;
			this.collisionNormal = collisionNormal;
            this.collisionType = type;
		}
	}
}

