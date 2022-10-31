using UnityEngine;

namespace LiteNinja.Common.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 FaceDirection(this Vector2 self, Vector2 direction)
        {
            var tangent = direction.x == 0
                ? direction.y >= 0 ? float.MaxValue : float.MinValue
                : direction.y / direction.x;
            var angle = Mathf.Atan(tangent).Rad2Deg();
            if (direction.x < 0) angle += 180;

            return self.RotateToAngle(angle.Deg2Rad());
        }

        public static Vector2 RotateToAngle(this Vector2 self, float angle)
        {
            return Quaternion.AngleAxis(angle.Rad2Deg(), new Vector3(0, 0, 1)) * self;
        }

        /// <summary>
        /// Gets max component from vector.
        /// </summary>
        public static float MaxComponent(this Vector2 self) => Mathf.Max(self.x, self.y);

        /// <summary>
        /// Gets min component from vector.
        /// </summary>
        public static float MinComponent(this Vector2 self) => Mathf.Min(self.x, self.y);

        /// <summary>
        /// Remaps all vector's components from one interval to other.
        /// </summary>
        public static Vector2 Remap(this Vector2 self, float sourceMin, float sourceMax, float targetMin,
            float targetMax)
        {
            return new Vector2(self.x.Remap(sourceMin, sourceMax, targetMin, targetMax),
                self.y.Remap(sourceMin, sourceMax, targetMin, targetMax));
        }
        
        public static Vector2Int ToVector2Int(this Vector2 self)
        {
            return new Vector2Int(Mathf.RoundToInt(self.x), Mathf.RoundToInt(self.y));
        }
        
        public static Vector3 ToVector3X0Y(this Vector2 self)
        {
            return new Vector3(self.x, 0f, self.y);
        }
        
        public static Vector3 x0y(this Vector2 self)
        {
            return new Vector3(self.x, 0f, self.y);
        }
        
        /// <summary>
        /// Multiplies component by component.
        /// </summary>
        /// <param name="thisVector">The this vector.</param>
        /// <param name="otherVector">The other vector.</param>
        public static Vector2 HadamardMod(this Vector2 thisVector, Vector2 otherVector)
        {
            return new Vector2(
                MathHelper.FloorMod(thisVector.x, otherVector.x), 
                MathHelper.FloorMod(thisVector.y, otherVector.y));
        }
        
        /// <summary>
        /// Multiplies one vector component wise by another.
        /// </summary>
        public static Vector2 HadamardMul(this Vector2 thisVector, Vector2 otherVector)
        {
            return new Vector2(thisVector.x * otherVector.x, thisVector.y * otherVector.y);
        }
        
        /// <summary>
        /// Divides one vector component by component by another.
        /// </summary>
        public static Vector2 HadamardDiv(this Vector2 thisVector, Vector2 otherVector)
        {
            return new Vector2(thisVector.x / otherVector.x, thisVector.y / otherVector.y);
        }
        
        /// <summary>
        /// Converts a 2D vector to a 3D vector using the vector 
        /// for the x and z coordinates, and the given value for the y coordinate.
        /// </summary>
        public static Vector3 To3DXZ(this Vector2 vector, float y)
        {
            return new Vector3(vector.x, y, vector.y);
        }

        /// <summary>
        /// Converts a 2D vector to a 3D vector using the vector 
        /// for the x and z coordinates, and 0 for the y coordinate.
        /// </summary>
        public static Vector3 To3DXZ(this Vector2 vector)
        {
            return vector.To3DXZ(0);
        }

        /// <summary>
        /// Converts a 2D vector to a 3D vector using the vector 
        /// for the x and y coordinates, and the given value for the z coordinate.
        /// </summary>
        public static Vector3 To3DXY(this Vector2 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        /// <summary>
        /// Converts a 2D vector to a 3D vector using the vector 
        /// for the x and y coordinates, and 0 for the z coordinate.
        /// </summary>
        public static Vector3 To3DXY(this Vector2 vector)
        {
            return vector.To3DXY(0);
        }

        /// <summary>
        /// Converts a 2D vector to a 3D vector using the vector 
        /// for the y and z coordinates, and the given value for the x coordinate.
        /// </summary>
        public static Vector3 To3DYZ(this Vector2 vector, float x)
        {
            return new Vector3(x, vector.x, vector.y);
        }

        /// <summary>
        /// Converts a 2D vector to a 3D vector using the vector 
        /// for the y and z coordinates, and 0 for the x coordinate.
        /// </summary>
        public static Vector3 To3DYZ(this Vector2 vector)
        {
            return vector.To3DYZ(0);
        }
        
        /// <summary>
        /// Equivalent to Vector2.Dot(v1.Perp(), v2).
        /// </summary>
        public static float PerpDot(this Vector2 vector1, Vector2 vector2)
        {
            return -vector1.y*vector2.x + vector1.x*vector2.y;
        }
    }
}