using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
	public class Sprite : BaseDrawable
	{
        public Quad quad;
        private Vector2 textureTopLeft,
            textureTopRight,
            textureBottomRight,
            textureBottomLeft;

		public Sprite (Vector2 textureCoords, uint width, uint height)
		{
            this.color = Color.White;
            this.width = width;
            this.height = height;
            this.quad = new Quad(new Vector2(0,0), new Vector2(this.width, 0), new Vector2(this.width, this.height), new Vector2(0, this.height));
            this.textureTopLeft = new Vector2(textureCoords.X, textureCoords.Y);
            this.textureTopRight = new Vector2(textureCoords.X + this.width, textureCoords.Y);
            this.textureBottomRight = new Vector2(textureCoords.X + this.width, textureCoords.Y + this.height);
            this.textureBottomLeft = new Vector2(textureCoords.X, textureCoords.Y + this.height);
		}

        public Sprite() { } 

        public Vector2 TextureTopLeft
        {
            get { return textureTopLeft; }
        }

        public Vector2 TextureTopRight
        {
            get { return textureTopRight; }
        }

        public Vector2 TextureBottomRight
        {
            get { return textureBottomRight; }
        }

        public Vector2 TextureBottomLeft
        {
            get { return textureBottomLeft; }
        }
	}
}

