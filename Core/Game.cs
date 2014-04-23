using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

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
        public int currentLevel = 0;

        public uint windowWidth = 1280;
        public uint windowHeight = 800;

		public SFML.Graphics.RenderWindow window;
        public SFML.Graphics.RenderStates renderStates;

        public delegate void Test(string message);

        Stopwatch timer;
        float deltaTime = 0;
        float oneFrameBack = 0;

		public Game ()
		{
			// Create the main window
			window = new SFML.Graphics.RenderWindow(new SFML.Window.VideoMode(windowWidth, windowHeight), "SFML window with OpenGL");
            //window.SetFramerateLimit(15);
          
			// Make it the active window for OpenGL calls
			window.SetActive();

            //window.SetFramerateLimit(60);
            window.SetVerticalSyncEnabled(true);
            timer = new Stopwatch();
            
		}

        public Level AddLevel(Vector2 cameraSize, Vector2 levelSize, Color ambientColor)
        {
            Surface diffuseSurface = new Surface((uint)levelSize.X, (uint)levelSize.Y);
            Surface lightMap = new Surface((uint)levelSize.X, (uint)levelSize.Y);
            Mouse mouse = new Mouse(window);
            Camera camera = new Camera(new Vector2(0, 0), cameraSize);
            Level newLevel = new Level(diffuseSurface, lightMap, mouse, camera, ambientColor);
            levels.Add(newLevel);
            return newLevel;
        }

        public void RemoveLevel(Level level)
        {
            levels.Remove(level);
        }

        public void SetCurrentLevel(int num)
        {
            currentLevel = num;
        }

        //Stopwatch updateTime = new Stopwatch();
        //Stopwatch renderTime = new Stopwatch();

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start() {
            timer.Start();
            //updateTime.Start();
            //renderTime.Start();
			window.GainedFocus += new EventHandler(GainedFocused);
			window.Closed += new EventHandler(CloseWindow);
			//window.Resized += new EventHandler(WindowResized);

			// ------ Main Game Loop ------
			while (window.IsOpen())
			{
                //deltaTime = ((float)timer.ElapsedMilliseconds / 1000);
                deltaTime = (float)new TimeSpan(timer.ElapsedTicks).Milliseconds / 1000;
                //Console.WriteLine("---");
                //Console.WriteLine((float)new TimeSpan(timer.ElapsedTicks).Milliseconds / 1000);
                if (deltaTime >= 0.016)
                {
                    //Console.WriteLine("Milli: " + timer.ElapsedMilliseconds);
                    //deltaTime = 0.015f;
                    //deltaTime = ((float)timer.ElapsedMilliseconds / 1000);
                    Console.WriteLine(deltaTime);
                    if (deltaTime > 0.0161)
                    {
                        //Console.WriteLine(deltaTime);
                    }
                    //updateTime.Reset();
                    //updateTime.Start();
                    //physics
                    levels[currentLevel].Update(deltaTime);

                    

                    //Console.WriteLine("update: " + updateTime.ElapsedMilliseconds + ", render: " + renderTime.ElapsedMilliseconds + ", Frame: " + deltaTime);
                    timer.Restart();
                }

                //renderTime.Reset();
                //renderTime.Start();
                window.SetView(levels[currentLevel].camera.SFMLView);
                // Clear surface each frame
                levels[currentLevel].diffuseSurface.Clear(Color.Black);
                levels[currentLevel].lightMap.Clear(levels[currentLevel].ambientColor);
                //renderTime.Stop();

                //updateTime.Stop();

                //renderTime.Start();
                //draw
                levels[currentLevel].Draw(deltaTime);

                // Clear window each frame
                window.Clear(SFML.Graphics.Color.Black);

                // Display surface textures
                levels[currentLevel].diffuseSurface.Display();
                levels[currentLevel].lightMap.Display();

                // Draw to window each frame (include window.display)
                levels[currentLevel].diffuseSurface.DrawToWindow(window);
                //renderTime.Stop();

                window.DispatchEvents();
			}
		}

        public void GainedFocused(object sender, EventArgs e)
        {
            Console.WriteLine("got here");
            //window.
        }

        public void CloseWindow(object sender, EventArgs e)
        {            
            window.Close();
            //this.CloseWindow();
        }

        public void WindowResized(object sender, EventArgs e)
        {
            //levels[currentLevel].
        }
	}
}

