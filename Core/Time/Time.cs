using System;
using System.Diagnostics;

namespace SpaceBagel
{
    /// <summary>Represents a time value.</summary>
    public class Time
    {
        #region Variables
        private long _elapsedticks = 0;
        private static Time _zero = new Time(0);
        #endregion

        #region Properties
        /// <summary>Predefined zero time value.</summary>
        public static Time Zero
        {
            get
            {
                return _zero;
            }
        }
        /// <summary>Gets or sets the ticks of this time instance.</summary>
        /// <remarks>It is not recomended to modify this directly.</remarks>
        public long Ticks
        {
            get
            {
                return _elapsedticks;
            }
            set
            {
                _elapsedticks = value;
            }
        }
        /// <summary>Gets or sets the milliseconds of this time instance.</summary>
        public long Milliseconds
        {
            get
            {
                return (long)(Seconds * 1000d);
            }
            set
            {
                Seconds = (double)value / 1000d;
            }
        }
        /// <summary>Gets or sets the seconds of this time instance.</summary>
        public double Seconds
        {
            get
            {
                return (double)Ticks / (double)Frequency;
            }
            set
            {
                Ticks = (long)(value * (double)Frequency);
            }
        }
        /// <summary>Gets or sets the minutes of this time instance.</summary>
        public float Minutes
        {
            get
            {
                return (float)Seconds / 60f;
            }
            set
            {
                Seconds = (double)value * 60d;
            }
        }
        /// <summary>Gets the number of ticks per second.</summary>
        public static long Frequency
        {
            get
            {
                return Stopwatch.Frequency;
            }
        }
        #endregion

        #region Contructors/Destructors
        /// <summary>Constructs a time with a length of zero</summary>
        public Time()
        {
            _elapsedticks = 0;
        }
        private Time(long TotalTicks)
        {
            _elapsedticks = TotalTicks;
        }
        /// <summary>Constructs a time with the specified number of ticks.</summary>
        public static Time FromTicks(long Ticks)
        {
            return new Time(Ticks);
        }
        /// <summary>Constructs a time with the specified number of milliseconds.</summary>
        public static Time FromMilliseconds(long Milliseconds)
        {
            return FromSeconds((double)Milliseconds / 1000d);
        }
        /// <summary>Constructs a time with the specified number of seconds.</summary>
        public static Time FromSeconds(double Seconds)
        {
            return FromTicks((long)(Seconds * (double)Frequency));
        }
        /// <summary>Constructs a time with the specified number of minutes.</summary>
        public static Time FromMinutes(float Minutes)
        {
            return FromSeconds((double)Minutes * 60d);
        }
        #endregion

        #region Functions
        public override bool Equals(object obj)
        {
            if (!(obj is Time)) return false;
            else return ((Time)obj)._elapsedticks == _elapsedticks;
        }
        #endregion

        #region Operators
        public static bool operator ==(Time a, Time b)
        {
            if (System.Object.ReferenceEquals(a, b)) return true;
            if (((object)a == null) || ((object)b == null)) return false;
            return (a._elapsedticks == b._elapsedticks);
        }
        public static bool operator !=(Time a, Time b)
        {
            if (System.Object.ReferenceEquals(a, b)) return false;
            if (((object)a == null) || ((object)b == null)) return false;
            return (a._elapsedticks != b._elapsedticks);
        }
        public static bool operator <(Time a, Time b)
        {
            return (a._elapsedticks < b._elapsedticks);
        }
        public static bool operator >(Time a, Time b)
        {
            return (a._elapsedticks > b._elapsedticks);
        }
        public static bool operator <=(Time a, Time b)
        {
            return (a._elapsedticks <= b._elapsedticks);
        }
        public static bool operator >=(Time a, Time b)
        {
            return (a._elapsedticks >= b._elapsedticks);
        }
        public static Time operator -(Time a)
        {
            return new Time(-a._elapsedticks);
        }
        public static Time operator +(Time a, Time b)
        {
            return new Time(a._elapsedticks + b._elapsedticks);
        }
        public static Time operator -(Time a, Time b)
        {
            return new Time(a._elapsedticks - b._elapsedticks);
        }
        public static Time operator *(Time a, Time b)
        {
            return new Time(a._elapsedticks * b._elapsedticks);
        }
        public static Time operator *(Time a, long b)
        {
            return new Time(a._elapsedticks * b);
        }
        public static Time operator *(Time a, double b)
        {
            return new Time((long)((double)a._elapsedticks * b));
        }
        public static Time operator *(Time a, float b)
        {
            return new Time((long)((double)a._elapsedticks * (double)b));
        }
        public static Time operator *(Time a, int b)
        {
            return new Time((long)((double)a._elapsedticks * (double)b));
        }
        public static Time operator /(Time a, Time b)
        {
            return new Time(a._elapsedticks / b._elapsedticks);
        }
        public static Time operator /(Time a, long b)
        {
            return new Time(a._elapsedticks / b);
        }
        public static Time operator /(Time a, double b)
        {
            return new Time((long)((double)a._elapsedticks / b));
        }
        public static Time operator /(Time a, float b)
        {
            return new Time((long)((double)a._elapsedticks / (double)b));
        }
        public static Time operator /(Time a, int b)
        {
            return new Time((long)((double)a._elapsedticks / (double)b));
        }
        #endregion
    }
}