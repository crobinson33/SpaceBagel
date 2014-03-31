using System;

namespace SpaceBagel
{
	/// <summary>
	/// Character collider, different from box collider
	/// </summary>
	public class CharacterCollider : Collider
	{
		public Vector2 size;




		public CharacterCollider()
		{
		}

		public CharacterCollider(Vector2 size, Vector2 position) : base(size, position, new Vector2(0, 0))
		{
			this.size = size;

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

