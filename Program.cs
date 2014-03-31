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
			Game game = new Game ();
			game.Start ();
		}
	}
}
