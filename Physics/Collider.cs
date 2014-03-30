using System;

namespace SpaceBagel
{
	/// <summary>
	/// Base Collider
	/// </summary>
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

