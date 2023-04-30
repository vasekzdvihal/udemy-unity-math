using System.Numerics;

public class Plane
{
  private Coords _a;
  private Coords _b;
  private Coords _c;
  private Coords _v;
  private Coords _u;

  public Plane(Coords a, Coords b, Coords c)
  {
    _a = a;
    _b = b;
    _c = c;
    _v = b - a;
    _u = c - a;
  }

  public Plane(Coords a, Vector3 v, Vector3 u)
  {
    _a = a;
    _v = new Coords(v.X, v.Y, v.Z);
    _u = new Coords(u.X, u.Y, u.Z);
  }

  public Coords Lerp(float s, float t)
  {
    var xst = _a.X + _v.X * s + _u.X * t;
    var yst = _a.Y + _v.Y * s + _u.Y * t;
    var zst = _a.Z + _v.Z * s + _u.Z * t;
    
    return new Coords(xst, yst, zst);
  }
}