using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    /// <summary>
    /// this is used for things like an item manager or enemy manager.
    /// </summary>
    public class Manager : BaseObject
    {
        public Manager(string tag) : base(tag)
        {

        }


        public override void Draw(Surface diffuseSurface, Surface lightMap, float deltaTime)
        {
            //base.Draw(diffuseSurface, lightMap, deltaTime);
        }

        public override void Update(float deltaTime)
        {
            //base.Update(deltaTime);
        }
    }
}
