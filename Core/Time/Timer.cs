using System;

namespace SpaceBagel
{
    /// <summary>Clock class that has the semantics of a countdown timer.</summary>
    public class Timer
    {
        #region Variables
        private StopWatch _stopwatch = new StopWatch();
        private Time _limit = Time.Zero;
        #endregion

        #region Properties
        /// <summary>Gets the remaining time.</summary>
        /// <remarks>If the timer has expired, Time.Zero is returned.</remarks>
        public Time RemainingTime
        {
            get
            {
                Time remaining = _limit - _stopwatch.ElapsedTime;
                if (remaining > Time.Zero) return remaining;
                else return Time.Zero;
            }
        }
        /// <summary>Gets a flag if the timer is currently running.</summary>
        public bool IsRunning
        {
            get
            {
                return _stopwatch.IsRunning && !IsExpired;
            }
        }
        /// <summary>Gets a flag if the timer has expired yet.</summary>
        public bool IsExpired
        {
            get
            {
                return _stopwatch.ElapsedTime >= _limit;
            }
        }
        #endregion

        #region Constructors
        /// <summary>Creates a timer that is initially expired.</summary>
        public Timer() { }
        #endregion

        #region Functions
        /// <summary>Starts or continues the timer.</summary>
        public virtual void Start()
        {
            _stopwatch.Start();
        }
        /// <summary>Pauses the timer.</summary>
        public virtual void Stop()
        {
            _stopwatch.Stop();
        }
        /// <summary>Resets the timer's remaining time to the given limit and stops it.</summary>
        /// <param name="TimeLimit">Time limit to wind the timer with</param>
        /// <remarks>In contrast to Restart(), the timer is not running after the call.</remarks>
        public virtual void Reset(Time TimeLimit)
        {
            _limit = TimeLimit;
            _stopwatch.Reset();
        }
        /// <summary>Resets the timer's remaining time to the given limit and starts it again.</summary>
        /// <param name="TimeLimit">Time limit to wind the timer with</param>
        public virtual void Restart(Time TimeLimit)
        {
            Reset(TimeLimit);
            Start();
        }
        #endregion
    }
}