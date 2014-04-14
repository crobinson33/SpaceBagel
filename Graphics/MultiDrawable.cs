using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class MultiDrawable
    {
        internal List<BaseDrawable> drawableParts;
        public BaseDrawable baseDrawable;
        public bool drawPartsInFront;

        public MultiDrawable(BaseDrawable baseDrawable)
        {
            drawableParts = new List<BaseDrawable>();
            this.baseDrawable = baseDrawable;
            drawPartsInFront = true;
        }

        public void AddDrawable(BaseDrawable drawable)
        {
            drawableParts.Add(drawable);
        }

        public void Update(Vector2 position, float deltaTime)
        {
            baseDrawable.Update(position, deltaTime);
            foreach (BaseDrawable obj in drawableParts)
            {
                obj.Update(position, deltaTime);
            }
        }
    }
}
