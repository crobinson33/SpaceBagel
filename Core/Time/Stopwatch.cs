using System;

namespace SpaceBagel
{
    /// <summary>Pausable clock class that measures elapsed time.</summary>
    /// <remarks>Unlike a clock, this stopwatch can be paused and continued at any time.</remarks>
    public class StopWatch
    {
        #region Variables
        private Time _timebuffer = Time.Zero;
        private Clock _clock = new Clock();
        private bool _isrunning = false;
        #endregion

        #region Properties
        /// <summary>Gets the totally elapsed time.</summary>
        public Time ElapsedTime
        {
            get
            {
                if (_isrunning)
                {
                    return _timebuffer + _clock.ElapsedTime;
                }
                else
                {
                    return _timebuffer;
                }
            }
        }
        /// <summary>Gets a flag if the stopwatch is currently running.</summary>
        public bool IsRunning
        {
            get
            {
                return _isrunning;
            }
        }
        #endregion

        #region Functions
        /// <summary>Starts or continues the stopwatch.</summary>
        public void Start()
        {
            if (!_isrunning)
            {
                _isrunning = true;
                _clock.Restart();
            }
        }
        /// <summary>Pauses the stopwatch.</summary>
        public void Stop()
        {
            if (_isrunning)
            {
                _isrunning = false;
                _timebuffer += _clock.ElapsedTime;
            }
        }
        /// <summary>Resets the stopwatch's elapsed time to zero and stops it.</summary>
        public void Reset()
        {
            _timebuffer = Time.Zero;
            _isrunning = false;
            _clock.Restart();
        }
        /// <summary>Resets the stopwatch's elapsed time to zero and starts it again.</summary>
        public void Restart()
        {
            Reset();
            Start();
        }
        #endregion
    }
}