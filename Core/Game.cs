using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SpaceBagel
{
	/// <summary>
	/// Creates everything game needs. Holds a list of levels.
	/// </summary>
	public class Game
	{
		/*
		 * Going to have all settingss in here like window height - width - framerate - resize options - etc.
		 */

		public List<Level> levels = new List<Level>();

		public int currentLevel;

		public SFML.Window.Window window;
		public World world;
		public Player player;
		public Sprite testSprite;
		public Texture testTexture;

		public Game ()
		{
			// Create the main window
			window = new SFML.Window.Window(new SFML.Window.VideoMode(640, 480), "SFML window with OpenGL");
			world = new World();
			player = new Player();
			world.AddCollider(player.collider);

			// Make it the active window for OpenGL calls
			window.SetActive();


		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start() {
			while (window.IsOpen())
			{
				// Process events
				window.DispatchEvents();

				window.draw ();

				// Finally, display the rendered frame on screen
				window.Display();

				world.Update();
			}
		}
	}
}

