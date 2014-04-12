using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SpaceBagel
{
	public class AnimationController
	{
        public Vector2 curFrameCoords;
        private int curFrame;
        public Animation activeAnimation;
        public List<Animation> animations = new List<Animation>();
        public AnimatedSprite aSprite;
        public bool animChanged;
        private float timeSinceFrame;

		public AnimationController (AnimatedSprite aSprite)
		{
            curFrameCoords = new Vector2(0, 0);
            this.aSprite = aSprite;
            animChanged = false;
            //this.activeAnimation = Lookup "default";
		}

        public void SetActiveAnimation(Animation animation)
        {
            activeAnimation = animation;
            animChanged = true;
        }

        public void AdvanceFrame(float deltaTime)
        {
            int frameCol;
            int frameRow;
            timeSinceFrame += deltaTime;

            if (animChanged)
            {
                curFrame = activeAnimation.startingFrame;
                animChanged = false;
            }
            else
            {
                if (timeSinceFrame > activeAnimation.speed)
                {
                    if (curFrame < ((activeAnimation.startingFrame + activeAnimation.numFrames) - 1))
                    {
                        curFrame++;
                    }
                    else
                    {
                        curFrame = activeAnimation.startingFrame;
                    }
                    timeSinceFrame = 0f;
                }
            }
            frameRow = curFrame / aSprite.columns;
            frameCol = curFrame % aSprite.columns;
            curFrameCoords.X = frameCol * aSprite.width;
            curFrameCoords.Y = frameRow * aSprite.height;
        }

	}
}

