﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
	public class Sprite : BaseDrawable
	{
        //public Quad quad;
        public Texture texture;

		public Sprite (Texture texture, int width, int height)
		{
            color = Color.White;
            this.width = width;
            this.height = height;
            //this.quad = new Quad(new Vector2(0,0), new Vector2(this.width, 0), new Vector2(this.width, this.height), new Vector2(0, this.height));
            //this.textureTopLeft = new Vector2(textureCoords.X, textureCoords.Y);
            //this.textureTopRight = new Vector2(textureCoords.X + this.width, textureCoords.Y);
            //this.textureBottomRight = new Vector2(textureCoords.X + this.width, textureCoords.Y + this.height);
            //this.textureBottomLeft = new Vector2(textureCoords.X, textureCoords.Y + this.height);
            //this.layer = layer;
            drawableSource = new SFML.Graphics.Sprite(texture.source);
            renderStates = SFML.Graphics.RenderStates.Default;
            this.yRenderOffset = this.height;
            this.z = 0;
		}

        public Sprite(Texture texture, int width, int height, int yRenderOffset)
        {
            color = Color.White;
            this.width = width;
            this.height = height;
            //this.quad = new Quad(new Vector2(0,0), new Vector2(this.width, 0), new Vector2(this.width, this.height), new Vector2(0, this.height));
            //this.textureTopLeft = new Vector2(textureCoords.X, textureCoords.Y);
            //this.textureTopRight = new Vector2(textureCoords.X + this.width, textureCoords.Y);
            //this.textureBottomRight = new Vector2(textureCoords.X + this.width, textureCoords.Y + this.height);
            //this.textureBottomLeft = new Vector2(textureCoords.X, textureCoords.Y + this.height);
            //this.layer = layer;
            drawableSource = new SFML.Graphics.Sprite(texture.source);
            renderStates = SFML.Graphics.RenderStates.Default;
            this.yRenderOffset = yRenderOffset;
            this.z = 0;
        }

        public Sprite(Texture texture, int width, int height, int yRenderOffset, int z)
        {
            color = Color.White;
            this.width = width;
            this.height = height;
            //this.quad = new Quad(new Vector2(0,0), new Vector2(this.width, 0), new Vector2(this.width, this.height), new Vector2(0, this.height));
            //this.textureTopLeft = new Vector2(textureCoords.X, textureCoords.Y);
            //this.textureTopRight = new Vector2(textureCoords.X + this.width, textureCoords.Y);
            //this.textureBottomRight = new Vector2(textureCoords.X + this.width, textureCoords.Y + this.height);
            //this.textureBottomLeft = new Vector2(textureCoords.X, textureCoords.Y + this.height);
            //this.layer = layer;
            drawableSource = new SFML.Graphics.Sprite(texture.source);
            renderStates = SFML.Graphics.RenderStates.Default;
            this.yRenderOffset = yRenderOffset;
            this.z = z;
        }

        public Sprite(Texture texture, Vector2 texCoords, int width, int height)
        {
            color = Color.White;
            this.width = width;
            this.height = height;
            //this.quad = new Quad(new Vector2(0,0), new Vector2(this.width, 0), new Vector2(this.width, this.height), new Vector2(0, this.height));
            //this.textureTopLeft = new Vector2(textureCoords.X, textureCoords.Y);
            //this.textureTopRight = new Vector2(textureCoords.X + this.width, textureCoords.Y);
            //this.textureBottomRight = new Vector2(textureCoords.X + this.width, textureCoords.Y + this.height);
            //this.textureBottomLeft = new Vector2(textureCoords.X, textureCoords.Y + this.height);
            //this.layer = layer;
            drawableSource = new SFML.Graphics.Sprite(texture.source, new SFML.Graphics.IntRect((int)texCoords.X, (int)texCoords.Y, width, height));
            renderStates = SFML.Graphics.RenderStates.Default;
            this.yRenderOffset = this.height;
            this.z = 0;
        }

        public Sprite(Texture texture, Vector2 texCoords, int width, int height, int yRenderOffset)
        {
            color = Color.White;
            this.width = width;
            this.height = height;
            //this.quad = new Quad(new Vector2(0,0), new Vector2(this.width, 0), new Vector2(this.width, this.height), new Vector2(0, this.height));
            //this.textureTopLeft = new Vector2(textureCoords.X, textureCoords.Y);
            //this.textureTopRight = new Vector2(textureCoords.X + this.width, textureCoords.Y);
            //this.textureBottomRight = new Vector2(textureCoords.X + this.width, textureCoords.Y + this.height);
            //this.textureBottomLeft = new Vector2(textureCoords.X, textureCoords.Y + this.height);
            //this.layer = layer;
            drawableSource = new SFML.Graphics.Sprite(texture.source, new SFML.Graphics.IntRect((int)texCoords.X, (int)texCoords.Y, width, height));
            renderStates = SFML.Graphics.RenderStates.Default;
            this.yRenderOffset = yRenderOffset;
            this.z = 0;
        }

        public Sprite(Texture texture, Vector2 texCoords, int width, int height,  int yRenderOffset, int z)
        {
            this.color = Color.White;
            this.width = width;
            this.height = height;
            //this.quad = new Quad(new Vector2(0,0), new Vector2(this.width, 0), new Vector2(this.width, this.height), new Vector2(0, this.height));
            //this.textureTopLeft = new Vector2(textureCoords.X, textureCoords.Y);
            //this.textureTopRight = new Vector2(textureCoords.X + this.width, textureCoords.Y);
            //this.textureBottomRight = new Vector2(textureCoords.X + this.width, textureCoords.Y + this.height);
            //this.textureBottomLeft = new Vector2(textureCoords.X, textureCoords.Y + this.height);
            //this.layer = layer;
            drawableSource = new SFML.Graphics.Sprite(texture.source, new SFML.Graphics.IntRect((int)texCoords.X, (int)texCoords.Y, width, height));
            renderStates = SFML.Graphics.RenderStates.Default;
            this.yRenderOffset = yRenderOffset;
            this.z = z;
        }

        public override void Update(Vector2 position, float deltaTime)
        {
            drawableSource.Position = position.SFMLVector2;
        }
	}
}

