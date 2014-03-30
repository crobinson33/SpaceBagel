using System;

namespace SpaceBagel
{
	public class Collider
	{
		public Collider ()
		{
		}

		public virtual bool OnCollisionEnter(Collider collider)
		{
			return false;
		}
	}
}

