using System;
using SFML.Window;

namespace SpaceBagel
{
	public class Mouse
	{
        Window window;
		public Mouse (Window window)
		{
            this.window = window;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Mouse buttons
		/// </summary>
		////////////////////////////////////////////////////////////
		public enum Button
		{
			/// <summary>The left mouse button</summary>
			Left,
			
			/// <summary>The right mouse button</summary>
			Right,
			
			/// <summary>The middle (wheel) mouse button</summary>
			Middle,
			
			/// <summary>The first extra mouse button</summary>
			XButton1,
			
			/// <summary>The second extra mouse button</summary>
			XButton2,
			
			/// <summary>Keep last -- the total number of mouse buttons</summary>
			ButtonCount
		};

		/// <summary>
		/// Check for mouse button down
		/// </summary>
		/// <returns><c>true</c> if this instance is mouse button down; otherwise, <c>false</c>.</returns>
		/// <param name="Button">Button.</param>
		public bool IsMouseButtonDown(Mouse.Button button)
		{
			//Console.WriteLine("got here");
			SFML.Window.Mouse.Button SFMLMouseButton;
			
			//Console.WriteLine("Key: " + key.ToString());
			Enum.TryParse(button.ToString(), out SFMLMouseButton);
			
			
			if (SFML.Window.Mouse.IsButtonPressed(SFMLMouseButton))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Gets mouse position none relative to window
		/// </summary>
		/// <returns>The mouse position.</returns>
		public Vector2 GetMousePosition()
		{
			return new Vector2(SFML.Window.Mouse.GetPosition(window).X, SFML.Window.Mouse.GetPosition(window).Y);
		}

		/// <summary>
		/// Gets the mouse position relative to window. I don't think we will use this unless we create our own window object
		/// </summary>
		/// <returns>The mouse position.</returns>
		/// <param name="window">Window.</param>
		//public Vector2 GetMousePosition(SFML.Window window)
		//{
		//	return SFML.Window.Mouse.GetPosition(window);
		//}


	}
}

