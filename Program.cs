using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace SpaceBagel
{
	class MainClass
	{
		public static void Main (string[] args)
		{

            SFMLProgram app = new SFMLProgram();
            app.StartWindow(); 
			while(true)
			{
				//Console.WriteLine("test");
				Keyboard keyboard = new Keyboard();

				/*List<Key.KeyCode> allKeysDown = new List<Key.KeyCode>();

				allKeysDown = keyboard.GetKeysDown();

				foreach (Key.KeyCode keyCode in allKeysDown)
				{
					Console.Write(keyCode.ToString() + ", ");
				}*/

				Console.WriteLine(keyboard.IsKeyDown(Key.KeyCode.Space));

				Console.WriteLine("end");
			}
		}
	}

    class SFMLProgram
    {
        RenderWindow mWindow;

        public void StartWindow()
        {
            mWindow = new RenderWindow(new VideoMode(800, 600), "Window");
            mWindow.SetVisible(true);
            mWindow.Closed += new EventHandler(OnClosed);

            while (mWindow.IsOpen())
            {
                mWindow.DispatchEvents();
                mWindow.Clear(Color.Yellow);
                mWindow.Display();
            }
        }

        void OnClosed(object sender, EventArgs e)
        {
            mWindow.Close();
        }
    }
}
