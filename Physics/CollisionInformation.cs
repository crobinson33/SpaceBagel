using System;

namespace SpaceBagel
{
	/// <summary>
	/// Needed to hold the info about collisions for the CollisionResolution object.
	/// </summary>
	public class CollisionInformation
	{
<<<<<<< HEAD
		public Collider object1;
		public Collider object2;
=======
		public Collider objectOne { get; set; }
		public Collider objectTwo { get; set; }

		public float penetrationAmount { get; set; }
>>>>>>> e1137e35fe3626b18c2511d795631d10073c186f

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

