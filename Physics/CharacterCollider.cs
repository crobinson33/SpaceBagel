using System;

namespace SpaceBagel
{
	public class CharacterCollider : Collider
	{
		public Vector2 size;
		public Vector2 position;

		public CharacterCollider()
		{
		}

		public CharacterCollider(Vector2 size, Vector2 position)
		{
			this.size = size;
			this.position = position;
		}

		public override bool OnCollisionEnter(Collider collider)
		{
			Console.WriteLine("got here");
			return true;
		}
	}
}

