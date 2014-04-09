using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SpaceBagel
{
	/// <summary>
	/// Creates everything game needs. Holds a list of levels.
	/// </summary>
	public class Game
	{
		/*
		 * Going to have all settings in here like window height - width - framerate - resize options - etc.
		 */

		public List<Level> levels = new List<Level>();

		public int currentLevel;
        public uint windowWidth = 800;
        public uint windowHeight = 600;

		public SFML.Graphics.RenderWindow window;
        public SFML.Graphics.RenderStates renderStates;
        public Surface surface;
		public World world;
		public Player player;
        public BoxCollider box;

        public Texture texture;
        public Sprite sprite;
        public Sprite sprite2;
        public Sprite sprite3;
        public Sprite sprite4;

        public delegate void Test(string message);

		public Game ()
		{
			// Create the main window
			window = new SFML.Graphics.RenderWindow(new SFML.Window.VideoMode(windowWidth, windowHeight), "SFML window with OpenGL");
            surface = new Surface(windowWidth, windowHeight, Color.Black);
			world = new World();
			player = new Player("player1", new Vector2(0, 0));
            box = new BoxCollider("box1", new Vector2(50, 50), new Vector2(10, 10));

            // Testing Rendering a Sprite with a Texture
            texture = new Texture("test.png");
            sprite = new Sprite(texture, new Vector2(0,0), 32, 32);
            sprite2 = new Sprite(texture, new Vector2(0,32), 32, 32);
            sprite3 = new Sprite(texture, new Vector2(32,32), 32, 32);
            sprite4 = new Sprite(texture, new Vector2(32,0), 32, 32);

			world.AddCollider(player.collider);
            world.AddCollider(box);

            Test test = Console.WriteLine;

            //player.collider.CreateOnCollisionEnter(box, () => test("got here"));


			// Make it the active window for OpenGL calls
			window.SetActive();
		}

        

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start() {
			while (window.IsOpen())
			{
                surface.Clear();

                // Testing rendering
                surface.Draw(sprite, new Vector2(0,0));
                surface.Draw(sprite2, new Vector2(0,128));
                surface.Draw(sprite3, new Vector2(514,423));
                surface.Draw(sprite4, new Vector2(10, 27));

                window.Clear();

                surface.DrawToWindow(window);

				world.Update();
                player.Update();
                //Console.WriteLine(player.position + ", " + box.position);
			}
		}
	}
}

