using System;

namespace SpaceBagel
{
	public class BaseObject
	{
		public Vector2 position { get; set; }
        public string tag;
        public BaseDrawable objectDrawable;

		public BaseObject (string tag)
		{
            this.tag = tag;
		}

        /// <summary>
        /// override this with game logic
        /// </summary>
        public virtual void Update(float deltaTime)
        {
            objectDrawable.Update(this.position, deltaTime);
            Console.WriteLine("got to baseupdate");
        }

        public virtual void Draw(Surface diffuseSurface, Surface lightMap, float deltaTime)
        {

        }
	}
}

