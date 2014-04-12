using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	/// <summary>
	/// Character collider, different from box collider
	/// </summary>
	public class CharacterCollider : Collider
	{
        

        /// <summary>
        /// Default constructor. Object always needs a tag.w
        /// </summary>
        /// <param name="tag"></param>
		public CharacterCollider(string tag) : base(tag)
		{
            // player should never be static
            this.isStatic = false;
		}

		public CharacterCollider(string tag, Vector2 size, Vector2 position) : base(size, position, new Vector2(1, 1))
		{
            this.tag = tag;
			this.size = size;

            // player should never be static
            this.isStatic = false;

			// Get internal variables set for collision detection
			CalculatePoints();
		}

		/// <summary>
		/// Get our topLeft and BottomRight. These are used in collision detection
		/// </summary>
		public override void CalculatePoints()
		{
			topLeft = position;
			bottomRight = new Vector2((position.X + size.X), (position.Y + size.Y));
		}

		/// <summary>
		/// Triggered when character collider collides with given collider.
		/// </summary>
		/// <param name="collider">Collider.</param>
        public override void CreateOnCollisionEnter(Collider collider, Action method)
		{
            CollisionTrigger newTrigger = new CollisionTrigger(collider, method);
            triggers.Add(newTrigger);
		}

        public void AddVelocity(Vector2 velocity)
        {
            this.velocity += velocity;
        }
	}
}

