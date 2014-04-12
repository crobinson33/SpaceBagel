using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
	public class Animation
	{
        public string name;
        public int startingFrame;
        public int numFrames;
        public float speed;
        
        //public int animType;

        //public enum animTypes { };

		public Animation (string name, int startingFrame, int numFrames, float speed)
		{
            this.name = name;
            this.startingFrame = startingFrame;
            this.numFrames = numFrames;
            this.speed = speed * 0.06f;
            //this.animType = (int)animType;
		}

        public Animation(string name, int startingFrame, int numFrames)
        {
            this.name = name;
            this.startingFrame = startingFrame;
            this.numFrames = numFrames;
            this.speed = 0.06f;
            //this.animType = (int)animType;
        }
	}
}

