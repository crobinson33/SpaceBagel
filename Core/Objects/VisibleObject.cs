using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class VisibleObject : BaseObject
    {
        public BaseDrawable objectDrawable;
		public bool isAlive = true;

        public VisibleObject(string tag)
            : base(tag) { }

        public virtual void Update(float deltaTime)
        {
            objectDrawable.Update(this.position, deltaTime);
            //Console.WriteLine("got to baseupdate");
        }

        public virtual void Draw(Surface diffuseSurface, Surface lightMap, float deltaTime)
        {

        }
    }
}
