public class Line
{
  private Coords A;
  private Coords B;
  private Coords v;

  public Line(Coords a, Coords b)
  {
    this.A = a;
    this.B = b;
    v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
  }

  public Coords GetPointAt(float t)
  {
    var xT = A.x + v.x * t;
    var yT = A.y + v.y * t;
    var zT = A.z + v.z * t;

    return new Coords(xT, yT, zT);
  }
}
