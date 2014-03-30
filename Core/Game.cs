using System;
using System.Collections.Generic;

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

		public Game ()
		{
		}
	}
}

