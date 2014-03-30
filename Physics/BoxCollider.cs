using System;

namespace SpaceBagel
{
	public class BoxCollider : Collider
	{
		public BoxCollider ()
		{
		}

		public override bool OnCollisionEnter(Collider collider)
		{
			return false;
		}
	}
}

