using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			while(true)
			{
				//Console.WriteLine("test");
				Keyboard keyboard = new Keyboard();
				Mouse mouse = new Mouse();

				/*List<Key.KeyCode> allKeysDown = new List<Key.KeyCode>();

				allKeysDown = keyboard.GetKeysDown();

				foreach (Key.KeyCode keyCode in allKeysDown)
				{
					Console.Write(keyCode.ToString() + ", ");
				}*/

				//Console.WriteLine(keyboard.IsKeyDown(Key.KeyCode.Space));

				Console.WriteLine(mouse.GetMousePosition());

				//Console.WriteLine("end");
			}
		}
	}
}
