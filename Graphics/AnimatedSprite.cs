using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class AnimatedSprite : BaseDrawable
    {
        public Texture texture;
        public Vector2 texCoords;
        public int columns;
        public int rows;
        public AnimationController animationController;

        public AnimatedSprite(Texture texture, int width, int height)
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
            drawableSource = new SFML.Graphics.Sprite(texture.source, new SFML.Graphics.IntRect((int)texCoords.X, (int)texCoords.Y, this.width, this.height));
            animationController = new AnimationController(this);
            renderStates = SFML.Graphics.RenderStates.Default;
            this.z = 0;
            this.yRenderOffset = this.height;
        }

        public AnimatedSprite(Texture texture, int width, int height, int yRenderOffset)
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
            drawableSource = new SFML.Graphics.Sprite(texture.source, new SFML.Graphics.IntRect((int)texCoords.X, (int)texCoords.Y, this.width, this.height));
            animationController = new AnimationController(this);
            renderStates = SFML.Graphics.RenderStates.Default;
            this.z = 0;
            this.yRenderOffset = yRenderOffset;
        }

        public AnimatedSprite(Texture texture, int width, int height, int yRenderOffset, int z)
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
            renderStates = SFML.Graphics.RenderStates.Default;
            this.yRenderOffset = yRenderOffset;
            this.z = z;
        }

        public void AddAnimation(Animation animation)
        {
            animationController.animations.Add(animation);
        }

        public override void Update(Vector2 position, float deltaTime)
        {
            animationController.AdvanceFrame(deltaTime);
            drawableSource.Position = position.SFMLVector2;
            //Console.WriteLine(drawableSource.Position);
            if (animationController.activeAnimation.flip == true)
            {
                drawableSource.TextureRect = new SFML.Graphics.IntRect((int)animationController.curFrameCoords.X + width, (int)animationController.curFrameCoords.Y, -this.width, this.height);
            }
            else
            {
                drawableSource.TextureRect = new SFML.Graphics.IntRect((int)animationController.curFrameCoords.X, (int)animationController.curFrameCoords.Y, this.width, this.height);
            }
	
        }

    }
}

