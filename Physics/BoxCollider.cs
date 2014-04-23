using System;

namespace SpaceBagel
{
	/// <summary>
	/// 2d Box collider.
	/// </summary>
	public class BoxCollider : Collider
	{
        public Vertex debugV1;
        public Vertex debugV2;
        public Vertex debugV3;
        public Vertex debugV4;
        public Vertex debugV5;

        /// <summary>
        /// Default constructor. We always have to have a tag.
        /// </summary>
        /// <param name="tag"></param>
		public BoxCollider (string tag) : base(tag)
		{
            CalculatePoints();

            debugDraw = new SFML.Graphics.VertexArray(SFML.Graphics.PrimitiveType.LinesStrip);
            debugV1 = new Vertex(this.position, Color.Green);
            debugV2 = new Vertex(new Vector2((this.position.X + size.X), this.position.Y), Color.Green);
            debugV3 = new Vertex(new Vector2((this.position.X + size.X), (this.position.Y + size.Y)), Color.Green);
            debugV4 = new Vertex(new Vector2(this.position.X, (this.position.Y + size.Y)), Color.Green);
            debugV5 = debugV1;
            debugDraw.Append(debugV1.SFMLVertex);
            debugDraw.Append(debugV2.SFMLVertex);
            debugDraw.Append(debugV3.SFMLVertex);
            debugDraw.Append(debugV4.SFMLVertex);
            debugDraw.Append(debugV5.SFMLVertex);
		}

		public BoxCollider(string tag, Vector2 size, Vector2 pos) : base(size, pos, new Vector2(0, 0))
		{
            this.tag = tag;
            CalculatePoints();

            debugDraw = new SFML.Graphics.VertexArray(SFML.Graphics.PrimitiveType.LinesStrip);
            debugV1 = new Vertex(this.position, Color.Green);
            debugV2 = new Vertex(new Vector2((this.position.X + size.X), this.position.Y), Color.Green);
            debugV3 = new Vertex(new Vector2((this.position.X + size.X), (this.position.Y + size.Y)), Color.Green);
            debugV4 = new Vertex(new Vector2(this.position.X, (this.position.Y + size.Y)), Color.Green);
            debugV5 = debugV1;
            debugDraw.Append(debugV1.SFMLVertex);
            debugDraw.Append(debugV2.SFMLVertex);
            debugDraw.Append(debugV3.SFMLVertex);
            debugDraw.Append(debugV4.SFMLVertex);
            debugDraw.Append(debugV5.SFMLVertex);
		}

        public void UpdateVertices()
        {
            debugV1 = new Vertex(this.position, Color.Green);
            debugV2 = new Vertex(new Vector2((this.position.X + size.X), this.position.Y), Color.Green);
            debugV3 = new Vertex(new Vector2((this.position.X + size.X), (this.position.Y + size.Y)), Color.Green);
            debugV4 = new Vertex(new Vector2(this.position.X, (this.position.Y + size.Y)), Color.Green);
            debugV5 = debugV1;
            debugDraw.Clear();
            debugDraw.Append(debugV1.SFMLVertex);
            debugDraw.Append(debugV2.SFMLVertex);
            debugDraw.Append(debugV3.SFMLVertex);
            debugDraw.Append(debugV4.SFMLVertex);
            debugDraw.Append(debugV5.SFMLVertex);
        }

        public void UpdateVertices(Color color)
        {
            debugV1 = new Vertex(this.position, color);
            debugV2 = new Vertex(new Vector2((this.position.X + size.X), this.position.Y), color);
            debugV3 = new Vertex(new Vector2((this.position.X + size.X), (this.position.Y + size.Y)), color);
            debugV4 = new Vertex(new Vector2(this.position.X, (this.position.Y + size.Y)), color);
            debugV5 = debugV1;
            debugDraw.Clear();
            debugDraw.Append(debugV1.SFMLVertex);
            debugDraw.Append(debugV2.SFMLVertex);
            debugDraw.Append(debugV3.SFMLVertex);
            debugDraw.Append(debugV4.SFMLVertex);
            debugDraw.Append(debugV5.SFMLVertex);
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

