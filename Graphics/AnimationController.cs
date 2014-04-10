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

        public void AdvanceFrame()
        {
            int frameCol;
            int frameRow;

            if (animChanged)
            {
                curFrame = activeAnimation.startingFrame;
                animChanged = false;
            }
            else
            {
                if (curFrame < ((activeAnimation.startingFrame + activeAnimation.numFrames) -1))
                {
                    curFrame++;
                }
                else
                {
                    curFrame = activeAnimation.startingFrame;
                }
            }
            frameRow = curFrame / aSprite.columns;
            frameCol = curFrame % aSprite.columns;
            //Console.WriteLine("frameRow is " + frameRow + ".");
            //Console.WriteLine("frameCol is " + frameCol + ".");
            curFrameCoords.X = frameCol * aSprite.width;
            curFrameCoords.Y = frameRow * aSprite.height;
            //Console.WriteLine("Frame is " + curFrame + ".");
            //Console.WriteLine("Xpx is " + curFrameCoords.X + ".");
            //Console.WriteLine("Ypx is " + curFrameCoords.Y + ".");
        }

	}
}

