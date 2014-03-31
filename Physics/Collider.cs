using System;

namespace SpaceBagel
{
	/// <summary>
	/// Base Collider
	/// </summary>
	public class Collider
	{
		public Vector2 topLeft;
		public Vector2 bottomRight;

		public Vector2 velocity;
		public Vector2 position;

		public Vector2 size;

		public float restitution;
		public float mass;

		public Collider ()
		{
		}

		public Collider(Vector2 size, Vector2 pos, Vector2 vel)
		{
			this.size = size;
			this.position = pos;
			this.velocity = vel;
		}

		public virtual bool OnCollisionEnter(Collider collider)
		{
			return false;
		}
	}
}

