using System;

namespace SpaceBagel
{
	/// <summary>
	/// Needed to hold the info about collisions for the CollisionResolution object.
	/// </summary>
	public class CollisionInformation
	{
		public BaseObject object1;
		public BaseObject object2;

		public int penetrationAmount;

		public CollisionInformation ()
		{
		}
	}
}

