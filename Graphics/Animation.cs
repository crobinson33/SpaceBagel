using System;

namespace SpaceBagel
{
	public class Animation
	{
        public string name;
        public int startingFrame;
        public int numFrames;
        public int animType;

        public enum animTypes { };

		public Animation (string name, int startingFrame, int numFrames, animTypes animType)
		{
            this.name = name;
            this.startingFrame = startingFrame;
            this.numFrames = numFrames;
            this.animType = (int)animType;
		}
	}
}

