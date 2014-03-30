using System;

namespace SpaceBagel
{
	/// <summary>
	/// Character collider, different from box collider
	/// </summary>
	public class CharacterCollider : Collider
	{
		public Vector2 size;
		public Vector2 position;


		public Vector2 topLeft;
		public Vector2 bottomRight;

		public CharacterCollider()
		{
		}

		public CharacterCollider(Vector2 size, Vector2 position)
		{
			this.size = size;
			this.position = position;

			// Get internal variables set for collision detection
			CalculatePoints();
		}

		/// <summary>
		/// Get our topLeft and BottomRight. These are used in collision detection
		/// </summary>
		public void CalculatePoints()
		{
			topLeft = position;
			bottomRight = new Vector2((position.X + size.X), (position.Y + size.Y));
		}

		/// <summary>
		/// Triggered when character collider collides with given collider.
		/// </summary>
		/// <param name="collider">Collider.</param>
		public override bool OnCollisionEnter(Collider collider)
		{
			Console.WriteLine("got here");
			return true;
		}
	}
}

