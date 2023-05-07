using System.Numerics;

public class Plane
{
  public readonly Coords A;
  public readonly Coords B;
  public readonly Coords C;
  public readonly Coords v;
  public readonly Coords u;

  public Plane(Coords a, Coords b, Coords c)
  {
    A = a;
    B = b;
    C = c;
    v = b - a;
    u = c - a;
  }

  public Plane(Coords a, Vector3 v, Vector3 u)
  {
    A = a;
    this.v = new Coords(v.X, v.Y, v.Z);
    this.u = new Coords(u.X, u.Y, u.Z);
  }

  public Coords Lerp(float s, float t)
  {
    var xst = A.X + v.X * s + u.X * t;
    var yst = A.Y + v.Y * s + u.Y * t;
    var zst = A.Z + v.Z * s + u.Z * t;
    
    return new Coords(xst, yst, zst);
  }
}