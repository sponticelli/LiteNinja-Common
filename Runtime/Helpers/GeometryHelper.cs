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

    /// <summary>
    /// Find the projection of a point onto a line.
    /// </summary>
    /// <param name="point">The point to project.</param>
    /// <param name="linePoint">A point on the line.</param>
    /// <param name="lineDirection">The direction of the line.</param>
    /// <returns>The projection of the point onto the line.</returns>
    public static Vector2 ProjectPointOnLine(Vector2 point, Vector2 linePoint, Vector2 lineDirection)
    {
      return linePoint + Vector2.Dot(point - linePoint, lineDirection) * lineDirection;
    }

    /// <summary>
    /// Find the projection of a point onto a line. The line is defined by two points.
    /// </summary>
    /// <param name="point">The point to project</param>
    /// <param name="firstPoint">first point of the line</param>
    /// <param name="seconPoint">second point of the line</param>
    /// <returns>The projection of the point onto the line defined by the 2 points</returns>
    public static Vector2 ProjectPointOnLine2(Vector2 point, Vector2 firstPoint, Vector2 secondPoint)
    {
      return ProjectPointOnLine(point, firstPoint, secondPoint - firstPoint);
    }
    
    /// <summary>
    /// Find the projection of a point onto a line segment.
    /// </summary>
    /// <param name="point">The point to project.</param>
    /// <param name="linePoint1">A point on the line segment.</param>
    /// <param name="linePoint2">Another point on the line segment.</param>
    /// <returns>The projection of the point onto the line segment.</returns>
    public static Vector2 ProjectPointOnLineSegment(Vector2 point, Vector2 linePoint1, Vector2 linePoint2)
    {
      var lineDirection = linePoint2 - linePoint1;
      var projectedPoint = ProjectPointOnLine(point, linePoint1, lineDirection);
      var projectedPointDistance = Vector2.Distance(linePoint1, projectedPoint);
      var lineDistance = Vector2.Distance(linePoint1, linePoint2);
      if (projectedPointDistance > lineDistance)
      {
        return linePoint2;
      }

      return projectedPointDistance < 0 ? linePoint1 : projectedPoint;
    }
    
    
    /// <summary>
    /// Find the distance between a point and a line.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="linePoint">A point on the line.</param>
    /// <param name="lineDirection">The direction of the line.</param>
    /// <returns>The distance between the point and the line.</returns>
    public static float DistancePointLine(Vector2 point, Vector2 linePoint, Vector2 lineDirection)
    {
      return Vector2.Distance(point, ProjectPointOnLine(point, linePoint, lineDirection));
    }
    
    /// <summary>
    /// Find the distance between a point and a line. The line is defined by two points.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="firstPoint">first point of the line</param>
    /// <param name="seconPoint">second point of the line</param>
    /// <returns>The distance between the point and the line.</returns>
    public static float DistancePointLine2(Vector2 point, Vector2 firstPoint, Vector2 secondPoint)
    {
      return DistancePointLine(point, firstPoint, secondPoint - firstPoint);
    }

    /// <summary>
    /// Find the projection of a point onto a line.
    /// </summary>
    /// <param name="point">The point to project.</param>
    /// <param name="linePoint">A point on the line.</param>
    /// <param name="lineDirection">The direction of the line.</param>
    /// <returns>The projection of the point onto the line.</returns>
    public static Vector3 ProjectPointOnLine(Vector3 point, Vector3 linePoint, Vector3 lineDirection)
    {
      return linePoint + Vector3.Dot(point - linePoint, lineDirection) * lineDirection;
    }

    /// <summary>
    /// Find the projection of a point onto a line. The line is defined by two points.
    /// </summary>
    /// <param name="point">The point to project</param>
    /// <param name="firstPoint">first point of the line</param>
    /// <param name="seconPoint">second point of the line</param>
    /// <returns>The projection of the point onto the line defined by the 2 points</returns>
    public static Vector3 ProjectPointOnLine2(Vector3 point, Vector3 firstPoint, Vector3 secondPoint)
    {
      return ProjectPointOnLine(point, firstPoint, secondPoint - firstPoint);
    }
    
    /// <summary>
    /// Find the projection of a point onto a line segment.
    /// </summary>
    /// <param name="point">The point to project.</param>
    /// <param name="linePoint1">A point on the line segment.</param>
    /// <param name="linePoint2">Another point on the line segment.</param>
    /// <returns>The projection of the point onto the line segment.</returns>
    public static Vector3 ProjectPointOnLineSegment(Vector3 point, Vector3 linePoint1, Vector3 linePoint2)
    {
      var lineDirection = linePoint2 - linePoint1;
      var projectedPoint = ProjectPointOnLine(point, linePoint1, lineDirection);
      var projectedPointDistance = Vector3.Distance(linePoint1, projectedPoint);
      var lineDistance = Vector3.Distance(linePoint1, linePoint2);
      if (projectedPointDistance > lineDistance)
      {
        return linePoint2;
      }

      return projectedPointDistance < 0 ? linePoint1 : projectedPoint;
    }
    
    
    /// <summary>
    /// Find the distance between a point and a line.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="linePoint">A point on the line.</param>
    /// <param name="lineDirection">The direction of the line.</param>
    /// <returns>The distance between the point and the line.</returns>
    public static float DistancePointLine(Vector3 point, Vector3 linePoint, Vector3 lineDirection)
    {
      return Vector3.Distance(point, ProjectPointOnLine(point, linePoint, lineDirection));
    }
    
    /// <summary>
    /// Find the distance between a point and a line. The line is defined by two points.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="firstPoint">first point of the line</param>
    /// <param name="seconPoint">second point of the line</param>
    /// <returns>The distance between the point and the line.</returns>
    public static float DistancePointLine2(Vector3 point, Vector3 firstPoint, Vector3 secondPoint)
    {
      return DistancePointLine(point, firstPoint, secondPoint - firstPoint);
    }
    
  }
}