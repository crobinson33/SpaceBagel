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

		public Player (string playerTag)
		{
            this.tag = playerTag;
			collider = new CharacterCollider(playerTag);
		}

        public Player(string playerTag, Vector2 pos)
        {
            this.tag = playerTag;
            collider = new CharacterCollider(playerTag, new Vector2(50, 50), pos);
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

