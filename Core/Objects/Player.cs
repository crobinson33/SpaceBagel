using System;

namespace SpaceBagel
{
	public class Player : BaseObject
	{
		public Vector2 velocity;
		public Vector2 position;

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

