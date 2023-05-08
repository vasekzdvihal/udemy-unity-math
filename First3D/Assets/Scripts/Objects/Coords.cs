using UnityEngine;

namespace Objects
{
  public class Coords
  {
    public float X;
    public float Y;
    public float Z;

    public Coords(float x, float y)
    {
      this.X = x;
      this.Y = y;
      this.Z = -1;
    }

    public Coords(float x, float y, float z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    public Coords(Vector3 vector)
    {
      this.X = vector.x;
      this.Y = vector.y;
      this.Z = vector.z;
    }

    /// <summary>
    /// <code>
    /// n = v X w
    /// </code>
    /// </summary>
    /// <returns></returns>
    public Coords GetNormal()
    {
      var magnitude = HolisticMath.Distance(new Coords(0, 0, 0), new Coords(X, Y, Z));
      return new Coords(X / magnitude, Y / magnitude, Z / magnitude);
    }

    /// <summary>
    /// Pepr v is a counterclockwise vector 90 degrees to v.
    /// <code>
    /// v⊥ = (-v.y, v.x)
    /// </code>
    /// </summary>
    /// <param name="v"></param>
    /// <returns>Returns new vector (counterclockwise 90 degrees to v)</returns>
    public static Coords Perp(Coords v)
    {
      return new Coords(-v.Y, v.X, 0);
    }

    public Vector3 ToVector3()
    {
      return new Vector3(X, Y, Z);
    }

    #region Operators
    public static Coords operator +(Coords a, Coords b)
    {
      return new Coords(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Coords operator -(Coords a, Coords b)
    {
      return new Coords(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Coords operator *(Coords a, float b)
    {
      return new Coords(a.X * b, a.Y * b, a.Z * b);
    }

    public static Coords operator /(Coords a, float b)
    {
      return new Coords(a.X / b, a.Y / b, a.Z / b);
    }
    #endregion

    #region Visualize
    public static void DrawPoint(Coords position, float width, Color color)
    {
      var line = new GameObject("Point_" + position.ToString());
      var lineRenderer = line.AddComponent<LineRenderer>();
      lineRenderer.material = new Material(Shader.Find("Unlit/Color"))
      {
        color = color
      };
      lineRenderer.positionCount = 2;
      lineRenderer.SetPosition(0, new Vector3(position.X - width / 3.0f, position.Y - width / 3.0f, position.Z));
      lineRenderer.SetPosition(1, new Vector3(position.X + width / 3.0f, position.Y + width / 3.0f, position.Z));
      lineRenderer.startWidth = width;
      lineRenderer.endWidth = width;
    }

    public static void DrawLine(Coords start, Coords end, float width, Color color)
    {
      var line = new GameObject($"Line_{start}_{end}");
      var lineRenderer = line.AddComponent<LineRenderer>();
      lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
      lineRenderer.material.color = color;
      lineRenderer.positionCount = 2;
      lineRenderer.SetPosition(0, new Vector3(start.X, start.Y, start.Z));
      lineRenderer.SetPosition(1, new Vector3(end.X, end.Y, end.Z));
      lineRenderer.startWidth = width;
      lineRenderer.endWidth = width;
    }

    public override string ToString()
    {
      return $"X: {X} Y: {Y} Z: {Z}";
    }
    #endregion

  }
}