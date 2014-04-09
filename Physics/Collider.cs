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
		public Vector2 position;

		public Vector2 size;

		public float restitution;
		public float mass = 1;

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

        public void Update()
        {
            this.position += this.velocity;
        }

		public virtual void CreateOnCollisionEnter(Collider collider, Action method)
		{
           // method();
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

