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

        }

        public virtual void Draw(Surface diffuseSurface, Surface lightMap, float deltaTime)
        {

        }
	}
}

