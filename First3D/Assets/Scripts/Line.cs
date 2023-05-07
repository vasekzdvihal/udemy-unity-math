using UnityEngine;

public class Line
{
  public readonly Coords A;
  public readonly Coords B;
  public readonly Coords v;

  private LineTypeEnum type;

  
  public enum LineTypeEnum
  {
    /// <summary>
    /// <code>
    /// Infinite &lt;= t &lt;= Infinite
    /// </code>
    /// </summary>
    Line,

    /// <summary>
    /// <code>
    /// 0 &lt;= t &lt;= 1
    /// </code>
    /// </summary>
    Segment,

    /// <summary>
    /// <code>
    /// 0 &lt;= t &lt;= Infinite
    /// </code>
    /// </summary>
    Ray
  }

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

  public void Draw(float width, Color col)
  {
    Coords.DrawLine(A, B, width, col);
  }

  public Coords Reflect(Coords normal)
  {
    var norm = normal.GetNormal();
    var vNorm = v.GetNormal();

    var d = HolisticMath.Dot(norm, vNorm);
    var vn2 = d * 2;
    var r = vNorm - norm * vn2;
    return r;
  }

  public float IntersectsAt(Plane p)
  {
    var normal = HolisticMath.Cross(p.u, p.v);

    if (HolisticMath.Dot(normal, v) == 0) {
      return float.NaN;
    }
    
    var t = HolisticMath.Dot(normal, p.A - A) / HolisticMath.Dot(normal, v);
    return t;
  }
  
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
}
