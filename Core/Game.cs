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
        public Texture atexture;
        public Sprite sprite;
        public Sprite sprite2;
        public Sprite sprite3;
        public Sprite sprite4;
        public AnimatedSprite asprite;
        public Animation defaultAnimation;
        public Animation downRunAnimation;

        public delegate void Test(string message);

		public Game ()
		{
			// Create the main window
			window = new SFML.Graphics.RenderWindow(new SFML.Window.VideoMode(windowWidth, windowHeight), "SFML window with OpenGL");
            window.SetFramerateLimit(15);
            surface = new Surface(windowWidth, windowHeight, Color.Black);
			world = new World();
			player = new Player("player1", new Vector2(0, 0));
            box = new BoxCollider("box1", new Vector2(50, 50), new Vector2(10, 10));

            // Create textures
            texture = new Texture("test.png");
            atexture = new Texture("HunchSprite.png");

            // Create sprites
            sprite = new Sprite(texture, new Vector2(0,0), 32, 32);
            sprite2 = new Sprite(texture, new Vector2(0,32), 32, 32);
            sprite3 = new Sprite(texture, new Vector2(32,32), 32, 32);
            sprite4 = new Sprite(texture, new Vector2(32,0), 32, 32);

            asprite = new AnimatedSprite(atexture, 64, 68);

            // Create animations
            downRunAnimation = new Animation("default", 0, 10);
            defaultAnimation = new Animation("downRun", 10, 7);

            // Add animations
            asprite.AddAnimation(defaultAnimation);
            asprite.AddAnimation(downRunAnimation);

            // Test animation
            asprite.animationController.SetActiveAnimation(downRunAnimation);

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
                // Clear surface each frame
                surface.Clear();

                // Draw to surface each frame
                surface.Draw(sprite, new Vector2(0,0));
                surface.Draw(sprite2, new Vector2(0,128));
                surface.Draw(sprite3, new Vector2(514,423));
                surface.Draw(sprite4, new Vector2(10, 27));
                surface.Draw(asprite, new Vector2(300, 300));

                // Clear window each frame
                window.Clear();

                // Draw to window each frame (include window.display)
                surface.DrawToWindow(window);

                // Update physics jazz
				world.Update();
                player.Update();
                //Console.WriteLine(player.position + ", " + box.position);
			}
		}
	}
}

