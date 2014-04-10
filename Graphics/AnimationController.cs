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
		}

        /// <summary>
        /// Sets current animation
        /// </summary>
        /// <param name="animation">Animation to set</param>
        public void SetActiveAnimation(Animation animation)
        {
            activeAnimation = animation;
            animChanged = true;
        }

        /// <summary>
        /// Advances the sprite to the next logical frame in the animation, or starts a new animation.
        /// </summary>
        public void AdvanceFrame()
        {
            int frameCol;
            int frameRow;

            // Start new animation
            if (animChanged)
            {
                curFrame = activeAnimation.startingFrame;
                animChanged = false;
            }
            else
            {
                // Advance to next frame in current animation
                if (curFrame < ((activeAnimation.startingFrame + activeAnimation.numFrames) -1))
                {
                    curFrame++;
                }
                // Restart animation
                else
                {
                    curFrame = activeAnimation.startingFrame;
                }
            }
            // Set texture coordinates of frame for sprite update call
            frameRow = curFrame / aSprite.columns;
            frameCol = curFrame % aSprite.columns;
            curFrameCoords.X = frameCol * aSprite.width;
            curFrameCoords.Y = frameRow * aSprite.height;
        }

	}
}

