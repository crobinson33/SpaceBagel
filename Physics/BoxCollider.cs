using System;

namespace SpaceBagel
{
	/// <summary>
	/// 2d Box collider.
	/// </summary>
	public class BoxCollider : Collider
	{
        /// <summary>
        /// Default constructor. We always have to have a tag.
        /// </summary>
        /// <param name="tag"></param>
		public BoxCollider (string tag) : base(tag)
		{
            CalculatePoints();
		}

		public BoxCollider(string tag, Vector2 size, Vector2 pos) : base(size, pos, new Vector2(0, 0))
		{
            this.tag = tag;
            CalculatePoints();
		}

        public void AddVelocity(Vector2 vel)
        {
            this.velocity += vel;
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
		/// Is triggered when this collider comes into contact with given collider
		/// </summary>
		/// <param name="collider">Collider.</param>
        public override void CreateOnCollisionEnter(Collider collider, Action method)
		{
            CollisionTrigger newTrigger = new CollisionTrigger(collider, method);
            triggers.Add(newTrigger);
		}

        public override void CreateOnCollisionEnter(string tag, Action method)
        {
            CollisionTrigger newTrigger = new CollisionTrigger(tag, method);
            triggers.Add(newTrigger);
            //Console.WriteLine("added trigger " + tag);
            //base.CreateOnCollisionEnter(tag, method);
        }
	}
}

