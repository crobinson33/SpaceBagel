using System;

namespace SpaceBagel
{
	public class Vector2
	{
		/// <summary>X (horizontal) component of the vector</summary>
		public float X;
		
		/// <summary>Y (vertical) component of the vector</summary>
		public float Y;

        public Vector2()
        {
            this.X = 0;
            this.Y = 0;
        }

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Construct the vector from its coordinates
		/// </summary>
		/// <param name="x">X coordinate</param>
		/// <param name="y">Y coordinate</param>
		////////////////////////////////////////////////////////////
		public Vector2(float x, float y)
		{
			X = x;
			Y = y;
		}

        /// <summary>
        /// Access SFML Vector 2 directly
        /// </summary>
        internal SFML.Window.Vector2f SFMLVector2
        {
            get { return new SFML.Window.Vector2f(this.X, this.Y); }
        }

		/// <summary>
		/// Calculates the Dot Product of two vectors
		/// </summary>
		/// <param name="vOne">V one.</param>
		/// <param name="vTwo">V two.</param>
		public float Dot(Vector2 vOne, Vector2 vTwo)
		{
			return ((vOne.X * vTwo.X) + (vOne.Y * vTwo.Y));
		}

        public Vector2 Normalize(float length)
        {
            //return new Vector2(this.X / Math.Abs(length), this.Y / Math.Abs(length));

            float hyp = (float)Math.Sqrt(length);
            return new Vector2(this.X / hyp, this.Y / hyp);
        }

        public void Normalize()
        {
            Vector2 newVector = Normalize(LengthSquared());
            this.X = newVector.X;
            this.Y = newVector.Y;
        }

        /// <summary>
        /// Get length
        /// </summary>
        /// <returns>Float</returns>
        public float LengthSquared()
        {
            return (float)((this.X * this.X) + (this.Y * this.Y));
        }
		
		////////////////////////////////////////////////////////////
		/// <summary>
		/// Operator - overload ; returns the opposite of a vector
		/// </summary>
		/// <param name="v">Vector to negate</param>
		/// <returns>-v</returns>
		////////////////////////////////////////////////////////////
		public static Vector2 operator -(Vector2 v)
		{
			return new Vector2(-v.X, -v.Y);
		}
		
		////////////////////////////////////////////////////////////
		/// <summary>
		/// Operator - overload ; subtracts two vectors
		/// </summary>
		/// <param name="v1">First vector</param>
		/// <param name="v2">Second vector</param>
		/// <returns>v1 - v2</returns>
		////////////////////////////////////////////////////////////
		public static Vector2 operator -(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
		}
		
		////////////////////////////////////////////////////////////
		/// <summary>
		/// Operator + overload ; add two vectors
		/// </summary>
		/// <param name="v1">First vector</param>
		/// <param name="v2">Second vector</param>
		/// <returns>v1 + v2</returns>
		////////////////////////////////////////////////////////////
		public static Vector2 operator +(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
		}
		
		////////////////////////////////////////////////////////////
		/// <summary>
		/// Operator * overload ; multiply a vector by a scalar value
		/// </summary>
		/// <param name="v">Vector</param>
		/// <param name="x">Scalar value</param>
		/// <returns>v * x</returns>
		////////////////////////////////////////////////////////////
		public static Vector2 operator *(Vector2 v, float x)
		{
			return new Vector2(v.X * x, v.Y * x);
		}
		
		////////////////////////////////////////////////////////////
		/// <summary>
		/// Operator * overload ; multiply a scalar value by a vector
		/// </summary>
		/// <param name="x">Scalar value</param>
		/// <param name="v">Vector</param>
		/// <returns>x * v</returns>
		////////////////////////////////////////////////////////////
		public static Vector2 operator *(float x, Vector2 v)
		{
			return new Vector2(v.X * x, v.Y * x);
		}
		
		////////////////////////////////////////////////////////////
		/// <summary>
		/// Operator / overload ; divide a vector by a scalar value
		/// </summary>
		/// <param name="v">Vector</param>
		/// <param name="x">Scalar value</param>
		/// <returns>v / x</returns>
		////////////////////////////////////////////////////////////
		public static Vector2 operator /(Vector2 v, float x)
		{
			return new Vector2(v.X / x, v.Y / x);
		}
		
		////////////////////////////////////////////////////////////
		/// <summary>
		/// Provide a string describing the object
		/// </summary>
		/// <returns>String description of the object</returns>
		////////////////////////////////////////////////////////////
		public override string ToString()
		{
			return "[Vector2]" +
				" X(" + X + ")" +
					" Y(" + Y + ")";
		}

		//public override Vector2 operator Equals(Window.Vector2 v)
		//{
		//
		//}
	}
}

