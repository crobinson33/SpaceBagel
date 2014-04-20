using System;
using System.Data.Linq;
using System.Collections.Generic;
using SFML.Window;

namespace SpaceBagel
{
	public class Keyboard
	{
		List<Key.KeyCode> allKeys;

		public Keyboard ()
		{
			allKeys = new List<Key.KeyCode>();
			Array keyCodes = Enum.GetValues(typeof(Key.KeyCode));
			foreach (Key.KeyCode keyCode in keyCodes)
			{
				//Console.WriteLine("KeyCode: " + keyCode.ToString());
				allKeys.Add(keyCode);
			}
			//allKeys = Enum.GetValues(typeof(Key.KeyCode))
		}

		/// <summary>
		/// Get all Keys being pressed down
		/// </summary>
		/// <returns>The keys down.</returns>
		public List<Key.KeyCode> GetKeysDown()
		{
			// create our container
			List<Key.KeyCode> toBeReturned = new List<Key.KeyCode>();

			// loop through all the key values
			foreach (Key.KeyCode keyCode in allKeys)
			{
				//Console.WriteLine("got here");
				SFML.Window.Keyboard.Key SFMLKey;

				//Console.WriteLine("Key: " + key.ToString());
				if (keyCode != Key.KeyCode.Unknown)
				{
					Enum.TryParse(keyCode.ToString(), out SFMLKey);


					if (SFML.Window.Keyboard.IsKeyPressed(SFMLKey))
					{
						toBeReturned.Add(keyCode);
					}
				}
			}

			return toBeReturned;
		}

		/// <summary>
		/// Determines whether the key is down.
		/// </summary>
		/// <returns><c>true</c> if the key is down; otherwise, <c>false</c>.</returns>
		/// <param name="keyCode">KeyCode</param>
		public bool IsKeyDown(Key.KeyCode keyCode)
		{
			//Console.WriteLine("got here");
			SFML.Window.Keyboard.Key SFMLKey;
			
			//Console.WriteLine("Key: " + key.ToString());
			if (keyCode != Key.KeyCode.Unknown)
			{
				Enum.TryParse(keyCode.ToString(), out SFMLKey);
				
				
				if (SFML.Window.Keyboard.IsKeyPressed(SFMLKey))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}

		/// <summary>
		/// Call this only to see if it is the only key down.
		/// </summary>
		/// <returns><c>true</c> if this instance is only key down the specified keyCode; otherwise, <c>false</c>.</returns>
		/// <param name="keyCode">Key code.</param>
		public bool IsOnlyKeyDown(Key.KeyCode keyCode)
		{
			// first make sure the key is down.
			if (IsKeyDown(keyCode))
			{
				foreach (Key.KeyCode key in allKeys)
				{
					if (IsKeyDown(key) && key != keyCode)
					{
						return false;
					}
				}
				// we made it through the loop without returning! must be the only one down.
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

