using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
	public class Shader
	{
        internal SFML.Graphics.Shader SFMLshader;

		public Shader (string vertexShaderFile, string fragmentShaderFile)
		{
            this.SFMLshader = new SFML.Graphics.Shader(vertexShaderFile, fragmentShaderFile);
		}

        public void SetParameter(string name, float x)
        {
            SFMLshader.SetParameter(name, x);
        }

        public void SetParameter(string name, float x, float y)
        {
            SFMLshader.SetParameter(name, x, y);
        }

        public void SetParameter(string name, float x, float y, float z)
        {
            SFMLshader.SetParameter(name, x, y, z);
        }

        public void SetParameter(string name, float x, float y, float z, float w)
        {
            SFMLshader.SetParameter(name, x, y, z, w);
        }

        public void SetParameter(string name, Vector2 vector)
        {
            SFMLshader.SetParameter(name, vector.SFMLVector2);
        }

        public void SetParameter(string name, Color color)
        {
            SFMLshader.SetParameter(name, color.SFMLColor);
        }

        public void SetParameter(string name, Texture texture)
        {
            SFMLshader.SetParameter(name, texture.source);
        }

        public void SetCurrentTextureParameter(string name)
        {
            SFMLshader.SetParameter(name, new SFML.Graphics.Shader.CurrentTextureType());
        }
	}
}

