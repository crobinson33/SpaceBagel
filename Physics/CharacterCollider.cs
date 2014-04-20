using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	/// <summary>
	/// Character collider, different from box collider
	/// </summary>
	public class CharacterCollider : Collider
	{

        public Vertex debugV1;
        public Vertex debugV2;
        public Vertex debugV3;
        public Vertex debugV4;
        public Vertex debugV5;

        /// <summary>
        /// Default constructor. Object always needs a tag.
        /// </summary>
        /// <param name="tag"></param>
		public CharacterCollider(string tag) : base(tag)
		{
            // player should never be static
            this.isStatic = false;

            debugDraw = new SFML.Graphics.VertexArray(SFML.Graphics.PrimitiveType.LinesStrip);
            debugV1 = new Vertex(this.topLeft, Color.Green);
            debugV2 = new Vertex(new Vector2((this.topLeft.X + size.X), this.topLeft.Y), Color.Green);
            debugV3 = new Vertex(this.bottomRight, Color.Green);
            debugV4 = new Vertex(new Vector2((this.bottomRight.X - size.X), this.bottomRight.Y), Color.Green);
            debugV5 = debugV1;
            debugDraw.Append(debugV1.SFMLVertex);
            debugDraw.Append(debugV2.SFMLVertex);
            debugDraw.Append(debugV3.SFMLVertex);
            debugDraw.Append(debugV4.SFMLVertex);
            debugDraw.Append(debugV5.SFMLVertex);
		}

		public CharacterCollider(string tag, Vector2 size, Vector2 position) : base(size, position, new Vector2(1, 1))
		{
            this.tag = tag;
			this.size = size;

            // player should never be static
            this.isStatic = false;

			// Get internal variables set for collision detection
			CalculatePoints();

            debugDraw = new SFML.Graphics.VertexArray(SFML.Graphics.PrimitiveType.LinesStrip);
            debugV1 = new Vertex(this.topLeft, Color.Green);
            debugV2 = new Vertex(new Vector2((this.topLeft.X + size.X), this.topLeft.Y), Color.Green);
            debugV3 = new Vertex(this.bottomRight, Color.Green);
            debugV4 = new Vertex(new Vector2((this.bottomRight.X - size.X), this.bottomRight.Y), Color.Green);
            debugV5 = debugV1;
            debugDraw.Append(debugV1.SFMLVertex);
            debugDraw.Append(debugV2.SFMLVertex);
            debugDraw.Append(debugV3.SFMLVertex);
            debugDraw.Append(debugV4.SFMLVertex);
            debugDraw.Append(debugV5.SFMLVertex);
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

        public void UpdateVertices()
        {
            debugV1.position = topLeft;
            debugV2.position = new Vector2((this.topLeft.X + size.X), this.topLeft.Y);
            debugV3.position = this.bottomRight;
            debugV4.position = new Vector2((this.bottomRight.X - size.X), this.bottomRight.Y);
            debugV5.position = debugV1.position;
            debugDraw.Clear();
            debugDraw.Append(debugV1.SFMLVertex);
            debugDraw.Append(debugV2.SFMLVertex);
            debugDraw.Append(debugV3.SFMLVertex);
            debugDraw.Append(debugV4.SFMLVertex);
            debugDraw.Append(debugV5.SFMLVertex);
        }

		public override void CreateOnCollisionEnter(string tag, Action method)
		{
			CollisionTrigger newTrigger = new CollisionTrigger(tag, method);
			triggers.Add(newTrigger);
		}

        public void AddVelocity(Vector2 velocity)
        {
            this.velocity += velocity;
        }
	}
}

