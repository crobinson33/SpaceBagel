using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	/// <summary>
	/// Base Collider
	/// </summary>
	public class Collider
	{
        public string tag;

		public Vector2 topLeft;
		public Vector2 bottomRight;

		public Vector2 velocity;
		public Vector2 position { get; set; }

        internal SFML.Graphics.VertexArray debugDraw;
        public bool debug;

		public Vector2 size;
        public float radius;

		public float restitution = 1;
		public float mass = 10;

        public float clearVelocityAmount = 0.95f;

        public List<string> layersToIgnore = new List<string>();


        // List of all triggers
        public List<CollisionTrigger> triggers = new List<CollisionTrigger>();

        // default set to false.
        public bool isStatic;

        /// <summary>
        /// Default constructor. We always need a tag.
        /// </summary>
        /// <param name="tag"></param>
		public Collider (string tag)
		{
            this.tag = tag;
            isStatic = false;
		}

		public Collider(Vector2 size, Vector2 pos, Vector2 vel)
		{
			this.size = size;
			this.position = pos;
			this.velocity = vel;
            //Console.WriteLine("Created with : " + this.velocity);
		}

        public void Update(float deltaTime)
        {
            //Console.WriteLine("got here");
            this.position += this.velocity * deltaTime;
            ClearVelocity();
            CheckVelocityToSetZero();
        }

        public void CheckVelocityToSetZero()
        {
            if (Math.Abs(this.velocity.X) < 0.1f && Math.Abs(this.velocity.Y) < 0.1f)
            {
                this.velocity = new Vector2(0, 0);
            }
        }

        public void ClearVelocity()
        {
            this.velocity *= clearVelocityAmount;
        }

		public virtual void CreateOnCollisionEnter(Collider collider, Action method)
		{
           // method();
		}

        public virtual void CreateOnCollisionEnter(string tag, Action method)
        {

        }

        public virtual void CalculatePoints()
        {

        }

        public virtual void DrawDebugBox(Surface surface, float deltaTime)
        {
            surface.Draw(this, this.position, deltaTime);
        }

        public void AddTagToIgnore(string tag)
        {
            layersToIgnore.Add(tag);
        }

        public void RemoveTagToIgnore(string tag)
        {
            layersToIgnore.Remove(tag);
        }
	}
}

