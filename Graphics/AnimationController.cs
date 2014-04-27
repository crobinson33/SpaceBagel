using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SpaceBagel
{
	public class AnimationController
	{
        public Vector2 curFrameCoords;
        public int curFrame;
        public Animation activeAnimation;
        public List<Animation> animations = new List<Animation>();
        public AnimatedSprite aSprite;
        public bool animChanged;
        private float timeSinceFrame;

        public bool hasReachedEnd = false;
        public bool dontLoop = false;

		public AnimationController (AnimatedSprite aSprite)
		{
            curFrameCoords = new Vector2(0, 0);
            this.aSprite = aSprite;
            animChanged = false;
            //this.activeAnimation = Lookup "default";
		}

        public void SetActiveAnimation(Animation animation)
        {
            // want to break early if it's already the animation.
            if (activeAnimation == animation)
            {
                return;
            }

            activeAnimation = animation;
            animChanged = true;
            hasReachedEnd = false;
        }

        public void AdvanceFrame(float deltaTime)
        {
            int frameCol;
            int frameRow;
            timeSinceFrame += (2 * deltaTime);
            //Console.WriteLine(timeSinceFrame);

            if (animChanged)
            {
                curFrame = activeAnimation.startingFrame;
                animChanged = false;
            }
            else
            {
                if (timeSinceFrame > activeAnimation.speed)
                {
                    //Console.WriteLine(timeSinceFrame + " has passed since frame");
                    if (curFrame < ((activeAnimation.startingFrame + activeAnimation.numFrames) - 1))
                    {
                        if (dontLoop && hasReachedEnd)
                        {
                            // we don't want to loop
                            //Console.WriteLine("not moving on");
                        }
                        else
                        {
                            curFrame++;
                        }
                    }
                    else
                    {
                        //Console.WriteLine("dont loop: " + dontLoop);
                        if (dontLoop)
                        {
                            //Console.WriteLine("not reseting");
                            hasReachedEnd = true;
                        }
                        else
                        {
                            //Console.WriteLine("reseting");
                            curFrame = activeAnimation.startingFrame;
                            hasReachedEnd = true;
                        }
                    }
                    timeSinceFrame = 0f;
                }
            }
            frameRow = curFrame / aSprite.columns;
            frameCol = curFrame % aSprite.columns;
            curFrameCoords.X = frameCol * aSprite.width;
            curFrameCoords.Y = frameRow * aSprite.height;
        }

		public string GetActiveAnimationName()
		{
			return activeAnimation.name;
		}

	}
}

