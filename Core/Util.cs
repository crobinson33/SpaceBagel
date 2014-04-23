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

        /// <summary>
        /// Utility method to clamp a value between max and min
        /// </summary>
        /// <param name="value">float value</param>
        /// <param name="min">float min</param>
        /// <param name="max">float max</param>
        /// <returns></returns>
        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            else
            {
                return value;
            }
        }

        public static Vector2 Lerp(Vector2 start, Vector2 end, float amount)
        {
            return start + ((end - start) * amount);
        }
    }
}
