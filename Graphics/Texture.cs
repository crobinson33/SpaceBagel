using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace SpaceBagel
{
    /// <summary>
    /// Wrapper for SFML Texture
    /// </summary>
	public class Texture
	{
		internal SFML.Graphics.Texture source;

		/// <summary>
		/// Creates a texture from a source file.
		/// </summary>
		/// <param name="source">Path of file to load texture from.</param>
		public Texture (string file) 
		{
            source = new SFML.Graphics.Texture(file);
		}

		/// <summary>
		/// Creates a texture from a stream of bytes.
		/// </summary>
		/// <param name="stream">Stream to load texture from.</param>
		public Texture (Stream stream)
		{
            source = new SFML.Graphics.Texture(stream);
		}

		/// <summary>
		/// Creates a texture from an array of bytes.
		/// </summary>
		/// <param name="bytes">Byte array to load texture from.</param>
		public Texture (byte[] bytes)
		{
			using (MemoryStream ms = new MemoryStream (bytes)) {
                source = new SFML.Graphics.Texture(ms);
			}
		}

		/// <summary>
		/// Creates an empty texture.
		/// </summary>
		/// <param name="width">Width of texture.</param>
		/// <param name="height">Height of texture.</param>
		public Texture(int width, int height)
		{
            source = new SFML.Graphics.Texture((uint)width, (uint)height);
		}

		public uint width {
            get { return source.Size.X; }
		}

		public uint height {
            get { return source.Size.Y; }
		}
			
	}
}

