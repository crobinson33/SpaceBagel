using System;
using System.Diagnostics;

namespace SpaceBagel
{
    /// <summary>Utility class that measures elapsed time.</summary>
    /// <remarks>Time begins counting as soon as the instance is constructed</remarks>
    public class Clock
    {
        #region Variables
        private Stopwatch _timer = Stopwatch.StartNew();
        #endregion

        #region Properties
        /// <summary>Gets the total time since the last call to restart or since the constructor was called.</summary>
        public Time ElapsedTime
        {
            get
            {
                return Time.FromTicks(_timer.ElapsedTicks);
            }
        }
        #endregion

        #region Functions
        /// <summary>Restarts the clock and sets elapsed time to zero,</summary>
        /// <returns>Elapsed time since last restart.</returns>
        public Time Restart()
        {
            Time tm = Time.FromTicks(_timer.ElapsedTicks);
            _timer.Reset();
            _timer.Start();
            return tm;
        }
        #endregion
    }
}