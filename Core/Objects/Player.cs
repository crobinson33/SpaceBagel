using System;

namespace SpaceBagel
{
	/// <summary>
	/// The Player Object.
	/// </summary>
	public class Player : BaseObject
	{
		// collider holds all position and velocity information
		public CharacterCollider collider;

		public Player ()
		{
			collider = new CharacterCollider();
		}

		/// <summary>
		/// Update the player.
		/// </summary>
		public void Update()
		{
			// set the players position equal to the collider
			position = collider.position;
		}
	}
}

