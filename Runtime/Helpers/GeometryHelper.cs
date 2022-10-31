using LiteNinja.Common.Extensions;
using UnityEngine;

namespace LiteNinja.Common
{
  public static class GeometryHelper
  {
    /// <summary>
    /// Determines whether a point is in the half plane described by a point and direction.
    /// </summary>
    /// <param name="point">The point to check.</param>
    /// <param name="halfPlanePoint">The half plane point.</param>
    /// <param name="halfPlaneDirection">The half plane direction.</param>
    /// <returns><c>true</c> if the point is in the half plane; otherwise, <c>false</c>.</returns>
    public static bool IsInHalfPlane(Vector2 point, Vector2 halfPlanePoint, Vector2 halfPlaneDirection)
    {
      return (point - halfPlanePoint).PerpDot(halfPlaneDirection) <= 0;
    }

    /// <summary>
    /// Determines whether a point is in the half (3D, hyper) plane described by a point and direction.
    /// </summary>
    /// <param name="point">The point to check.</param>
    /// <param name="halfPlanePoint">The half plane point.</param>
    /// <param name="halfPlaneDirection">The half plane direction.</param>
    /// <returns><c>true</c> if the point is in the half plane; otherwise, <c>false</c>.</returns>
    public static bool IsInHalfPlane(Vector3 point, Vector3 halfPlanePoint, Vector3 halfPlaneDirection)
    {
      return Vector3.Dot(point - halfPlanePoint, halfPlaneDirection) >= 0;
    }
  }
}