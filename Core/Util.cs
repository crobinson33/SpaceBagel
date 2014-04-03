using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    /// <summary>
    /// Static utility class for helper methods.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Utility method to clamp a float from 0.0 - 1.0.
        /// </summary>
        /// <param name="f">Float to clamp.</param>
        /// <returns>Clamped float.</returns>
        public static float Clamp(float f)
        {
            if (f < 0.0f) return 0.0f;
            else if (f > 1.0f) return 1.0f;
            else return f;
        }
    }
}
