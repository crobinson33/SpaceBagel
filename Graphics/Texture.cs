﻿using System;
using System.IO;
using SFML.Graphics;

namespace SpaceBagel
{
	public class Texture
	{
		internal SFML.Graphics.Texture texture;

		/// <summary>
		/// Creates a texture from a source file.
		/// </summary>
		/// <param name="source">Path of file to load texture from.</param>
		public Texture (string source) 
		{
			texture = new SFML.Graphics.Texture(source);
		}

		/// <summary>
		/// Creates a texture from a stream of bytes.
		/// </summary>
		/// <param name="stream">Stream to load texture from.</param>
		public Texture (Stream stream)
		{
			texture = new SFML.Graphics.Texture (stream);
		}

		/// <summary>
		/// Creates a texture from an array of bytes.
		/// </summary>
		/// <param name="bytes">Byte array to load texture from.</param>
		public Texture (byte[] bytes)
		{
			using (MemoryStream ms = new MemoryStream (bytes)) {
				texture = new SFML.Graphics.Texture (ms);
			}
		}

		/// <summary>
		/// Creates an empty texture.
		/// </summary>
		/// <param name="width">Width of texture.</param>
		/// <param name="height">Height of texture.</param>
		public Texture(int width, int height)
		{
			if (width < 0) throw new ArgumentException("Width must be a nonnegative integer.");
			if (height < 0) throw new ArgumentException("Height must be a nonnegative integer.");

			texture = new SFML.Graphics.Texture ((uint)width, (uint)height);
		}

		public int Width {
			get { return (int)texture.Size.X; }
		}

		public int Height {
			get { return (int)texture.Size.Y; }
		}
			
	}
}

