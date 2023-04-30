using UnityEngine;

public class Line
{
  private Coords A;
  private Coords B;
  private Coords v;

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
    v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
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
    } else if (type == LineTypeEnum.Ray) {
      t = 0;
    }
    
    
    var xT = A.x + v.x * t;
    var yT = A.y + v.y * t;
    var zT = A.z + v.z * t;

    return new Coords(xT, yT, zT);
  }
}
