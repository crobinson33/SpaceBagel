using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
	public class AnimatedSprite : BaseDrawable
	{
        internal SFML.Graphics.Sprite drawableSource;
        public Texture texture;
        public Vector2 texCoords;
        public int columns;
        public int rows;
        public AnimationController animationController;

        public AnimatedSprite (Texture texture, int width, int height)
		{
            color = Color.White;
            this.width = width;
            this.height = height;
            columns = (int)texture.source.Size.X / width;
            rows = (int)texture.source.Size.Y / height;
            //this.quad = new Quad(new Vector2(0,0), new Vector2(this.width, 0), new Vector2(this.width, this.height), new Vector2(0, this.height));
            //this.textureTopLeft = new Vector2(textureCoords.X, textureCoords.Y);
            //this.textureTopRight = new Vector2(textureCoords.X + this.width, textureCoords.Y);
            //this.textureBottomRight = new Vector2(textureCoords.X + this.width, textureCoords.Y + this.height);
            //this.textureBottomLeft = new Vector2(textureCoords.X, textureCoords.Y + this.height);
            //this.layer = layer;
            texCoords = new Vector2(0, 0);
            drawableSource = new SFML.Graphics.Sprite(texture.source, new SFML.Graphics.IntRect((int)texCoords.X, (int)texCoords.Y ,this.width, this.height));
            animationController = new AnimationController(this);
            this.z = 0;
		}

        public AnimatedSprite(Texture texture, int width, int height, int z)
        {
            color = Color.White;
            this.width = width;
            this.height = height;
            rows = (int)texture.source.Size.X / width;
            columns = (int)texture.source.Size.Y / height;
            //this.quad = new Quad(new Vector2(0,0), new Vector2(this.width, 0), new Vector2(this.width, this.height), new Vector2(0, this.height));
            //this.textureTopLeft = new Vector2(textureCoords.X, textureCoords.Y);
            //this.textureTopRight = new Vector2(textureCoords.X + this.width, textureCoords.Y);
            //this.textureBottomRight = new Vector2(textureCoords.X + this.width, textureCoords.Y + this.height);
            //this.textureBottomLeft = new Vector2(textureCoords.X, textureCoords.Y + this.height);
            //this.layer = layer;
            texCoords = new Vector2(0, 0);
            drawableSource = new SFML.Graphics.Sprite(texture.source, new SFML.Graphics.IntRect((int)texCoords.X, (int)texCoords.Y, width, height));
            animationController = new AnimationController(this);
            this.z = z;
        }

        public void AddAnimation(Animation animation)
        {
            animationController.animations.Add(animation);
        }

        public void Update(Vector2 position)
        {
            animationController.AdvanceFrame();
            drawableSource.Position = position.SFMLVector2;
            drawableSource.TextureRect = new SFML.Graphics.IntRect((int)animationController.curFrameCoords.X, (int)animationController.curFrameCoords.Y, this.width, this.height);
        }
	}
}

