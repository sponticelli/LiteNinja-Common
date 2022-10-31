using System;
using UnityEngine;

namespace LiteNinja.Common
{
    public static class MathHelper
    {
        public static double Angle(double cx, double cy, double px, double py)
        {
            var num = 180.0 / Math.PI * Math.Atan2(py - cy, px - cx);
            if (num < 0.0)
                num += 360.0;
            return num;
        }

        public static double Angle(Vector2 center, Vector2 point)
        {
            return Angle(center.x, center.y, point.x, point.y);
        }


        /// <summary>
        /// Mod operator that also works for negative m.
        /// </summary>
        public static int FloorMod(int m, int n)
        {
            if (m >= 0)
            {
                return m % n;
            }

            return (m - 2 * m * n) % n;
        }
        
        /// <summary>
        /// Mod operator that also works for negative m.
        /// </summary>
        public static float FloorMod(float m, float n)
        {
            if (m >= 0)
            {
                return m % n;
            }

            return (m % n) + n;
        }
        
        /// <summary>
        /// Floor division that also work for negative m.
        /// </summary>
        public static int FloorDiv(int m, int n)
        {
            if (m >= 0)
            {
                return m / n;
            }

            var t = m / n;

            if (t * n == m)
            {
                return t;
            }

            return t - 1;
        }
        
        /// <summary>
        /// Returns the fractional part of a floating point number.
        /// </summary>
        public static float Frac(float x)
        {
            return x - Mathf.Floor(x);
        }
        
        /// <summary>
        /// Returns the sign function evaluated at the given value.
        /// </summary>
        /// <returns>1 if the given value is positive, -1 if it is negative, and 0 if it is 0.</returns>
        public static int Sign(float x)
        {
            return x switch
            {
                > 0 => 1,
                < 0 => -1,
                _ => 0
            };
        }
        
        /// <summary>
        /// Returns the sign function evaluated at the given value.
        /// </summary>
        /// <returns>1 if the given value is positive, -1 if it is negative, and 0 if it is 0.</returns>
        public static int Sign(int p)
        {
            return p switch
            {
                > 0 => 1,
                < 0 => -1,
                _ => 0
            };
        }
    }
}