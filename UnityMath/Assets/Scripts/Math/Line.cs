using UnityEngine;

namespace Math
{
  public class Line
  {
    public readonly Coords A;
    public readonly Coords B;
    public readonly Coords v;

    private LineTypeEnum type;
    
    public Line(Coords a, Coords b, LineTypeEnum type = LineTypeEnum.Line)
    {
      this.A = a;
      this.B = b;
      this.type = type;
      v = new Coords(B.X - A.X, B.Y - A.Y, B.Z - A.Z);
    }

    public Line(Coords a, Coords v)
    {
      this.A = a;
      this.B = a + v;
      this.v = v;
      this.type = LineTypeEnum.Segment;
    }

    /// <summary>
    /// <code>
    /// r = a - 2(a.n)n
    /// </code>
    /// </summary>
    /// <param name="normal">Normal vector</param>
    /// <returns>Reflect vector</returns>
    public Coords Reflect(Coords normal)
    {
      var norm = normal.GetNormal();
      var vNorm = v.GetNormal();

      var d = HolisticMath.Dot(norm, vNorm);

      if (d == 0) {
        return v; // No reflection, keep travelling in the same direction
      }
    
      var vn2 = d * 2;
      var r = vNorm - norm * vn2;
      return r;
    }

    /// <summary>
    /// <code>
    /// t = (normal.(p.A - A)) / (normal.v)
    /// </code>
    /// </summary>
    /// <param name="p">Plane which we want check intersections</param>
    /// <returns>Point of intersect or NaN of there is no intersection.</returns>
    public float IntersectsAt(Plane p)
    {
      var normal = HolisticMath.Cross(p.u, p.v);

      if (HolisticMath.Dot(normal, v) == 0) {
        return float.NaN;
      }
    
      var t = HolisticMath.Dot(normal, p.A - A) / HolisticMath.Dot(normal, v);
      return t;
    }
  
    /// <summary>
    /// <code>
    /// t = (u⊥.c) / (u⊥.v)
    /// s = (v⊥.c) / (u⊥.v)
    /// </code>
    /// </summary>
    /// <param name="l">Line where we want check intersection</param>
    /// <returns>Point of intersect or NaN of there is no intersection.</returns>
    public float IntersectsAt(Line l)
    {
      if (HolisticMath.Dot(Coords.Perp(l.v), v) == 0) {
        return float.NaN;
      }
    
      var c = l.A - this.A;
      var t = HolisticMath.Dot(Coords.Perp(l.v), c) / HolisticMath.Dot(Coords.Perp(l.v), v);
    
      if (t is < 0 or > 1 && type == LineTypeEnum.Segment) {
        return float.NaN;
      }
    
      return t;
    }

    /// <summary>
    /// <code>
    /// L(t) = A + v * t
    /// </code>
    /// </summary>
    public Coords Lerp(float t)
    {
      // Handle infinite lines
      if (type == LineTypeEnum.Segment) {
        t = Mathf.Clamp(t, 0, 1);
      } else if (type == LineTypeEnum.Ray && t < 0) {
        t = 0;
      }
    
    
      var xT = A.X + v.X * t;
      var yT = A.Y + v.Y * t;
      var zT = A.Z + v.Z * t;

      return new Coords(xT, yT, zT);
    }

    #region Visualize
    public void Draw(float width, Color col)
    {
      Coords.DrawLine(A, B, width, col);
    }
    #endregion
  }
}
