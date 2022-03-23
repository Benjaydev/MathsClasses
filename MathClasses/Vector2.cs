using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector2
    {
        // Initialise vector values
        public float x, y;

        // Constructor
        public Vector2()
        {
            x = y = 0;
        }

        // Constructor
        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }
        public Vector2(Vector2 v)
        {
            x = v.x;
            y = v.y;
        }

        // Calculate and return the dot product of this vector and another vector
        public float Dot(Vector2 v)
        {
            return (x * v.x) + (y * v.y);
        }

        // Calculate the maginitude of vector (Length)
        public float Magnitude()
        {
            return (float) Math.Sqrt(this.Dot(this));
        }

        // Normalise this vector
        public void Normalize()
        {
            float magnitude = Magnitude();
            x /= magnitude;
            y /= magnitude;
        }

        // Overload addition operator for adding vector and vector (Translation)
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        // Overload subtract operator for subtracting vector and vector (Translation)
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        // Overload negative base operator to set vector values to negative
        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }
        // Overload multiply operator for multiplying vector and vector 
        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        }
        // Overload multiply operator for multiplying vector by float (Scale)
        public static Vector2 operator *(Vector2 v, float f) 
        {
            return new Vector2(v.x * f, v.y * f);
        }
        // Overload multiply operator for multiplying float by vector (Scale)
        public static Vector2 operator *(float f, Vector2 v)
        {
            return new Vector2(v.x * f, v.y * f);
        }
        

    }
}
