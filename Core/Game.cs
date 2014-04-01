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
        public BoxCollider box;

        public delegate void Test(string message);

		public Game ()
		{
			// Create the main window
			window = new SFML.Window.Window(new SFML.Window.VideoMode(640, 480), "SFML window with OpenGL");
			world = new World();
			player = new Player("player1", new Vector2(0, 0));
            box = new BoxCollider("box1", new Vector2(50, 50), new Vector2(10, 10));

			world.AddCollider(player.collider);
            world.AddCollider(box);

            Test test = Console.WriteLine;

            player.collider.CreateOnCollisionEnter(box, () => test("got here"));


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

				// Finally, display the rendered frame on screen
				window.Display();

				world.Update();
                player.Update();
                Console.WriteLine(player.position + ", " + box.position);
			}
		}
	}
}

