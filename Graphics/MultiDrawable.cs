using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class MultiDrawable : BaseDrawable
    {
        internal List<BaseDrawable> drawableParts;
        public BaseDrawable baseDrawable;
        public bool drawPartsInFront;

        public MultiDrawable(BaseDrawable baseDrawable)
        {
            drawableParts = new List<BaseDrawable>();
            this.baseDrawable = baseDrawable;
            this.width = baseDrawable.width;
            this.height = baseDrawable.height;
            this.yRenderOffset = baseDrawable.yRenderOffset;
            drawPartsInFront = true;
        }

        public MultiDrawable(BaseDrawable baseDrawable, int z)
        {
            drawableParts = new List<BaseDrawable>();
            this.baseDrawable = baseDrawable;
            this.width = baseDrawable.width;
            this.height = baseDrawable.height;
            this.yRenderOffset = baseDrawable.yRenderOffset;
            drawPartsInFront = true;
            this.z = z;
        }

        public void AddDrawable(BaseDrawable drawable)
        {
            drawableParts.Add(drawable);
        }

        public override void Update(Vector2 position, float deltaTime)
        {
            baseDrawable.Update(position, deltaTime);
            foreach (BaseDrawable drawable in drawableParts)
            {
                drawable.Update(position, deltaTime);
            }
        }
    }
}
