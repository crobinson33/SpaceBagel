using System;
using System.Runtime.InteropServices;
using SFML.Window;
using Tao.OpenGl;


namespace SpaceBagel
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
			Game game = new Game ();
			game.Start ();
		}
	}
}
