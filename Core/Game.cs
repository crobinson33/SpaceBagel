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

        // Testing Rendering a Sprite with a Texture
        public Texture spriteTexture;
        public Sprite sprite;
        public Texture spriteTexture2;
        public Sprite sprite2;

        public delegate void Test(string message);

		public Game ()
		{
			// Create the main window
			window = new SFML.Graphics.RenderWindow(new SFML.Window.VideoMode(windowWidth, windowHeight), "SFML window with OpenGL");
            surface = new Surface(windowWidth, windowHeight, new Color(0.0f,0.0f,0.0f,1.0f), window);
            renderStates = new SFML.Graphics.RenderStates();
			world = new World();
			player = new Player("player1", new Vector2(0, 0));
            box = new BoxCollider("box1", new Vector2(50, 50), new Vector2(10, 10));

            // Testing Rendering a Sprite with a Texture
            spriteTexture = new Texture("test.png");
            spriteTexture2 = new Texture("test2.png");
            sprite = new Sprite(spriteTexture);
            sprite2 = new Sprite(spriteTexture2);
            sprite.sprite.Position = new SFML.Window.Vector2f(0f,0f);
            sprite2.sprite.Position = new SFML.Window.Vector2f(32f,0f);

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
                surface.Clear();
                // Testing rendering
                surface.Draw(sprite);
                surface.Draw(sprite2);

                window.Clear();

                surface.DrawToWindow();
				// Finally, display the rendered frame on screen
				window.Display();

				world.Update();
                player.Update();
                //Console.WriteLine(player.position + ", " + box.position);
			}
		}
	}
}

