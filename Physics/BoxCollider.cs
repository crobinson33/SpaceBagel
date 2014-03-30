using System;

namespace SpaceBagel
{
	/// <summary>
	/// 2d Box collider.
	/// </summary>
	public class BoxCollider : Collider
	{
		// will control if the object gets resolved. If static the object will not move.
		public bool isStatic;

		public BoxCollider ()
		{
		}

		/// <summary>
		/// Is triggered when this collider comes into contact with given collider
		/// </summary>
		/// <param name="collider">Collider.</param>
		public override bool OnCollisionEnter(Collider collider)
		{
			return false;
		}
	}
}
