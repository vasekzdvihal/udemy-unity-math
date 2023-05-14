using Objects;
using UnityEngine;

public static class HolisticMath
{
    public static void LookAt(Transform transform, Vector3 target)
    {
        var up = new Coords(transform.up);
        var direction = target - transform.position;

        transform.up = Rotate(up, Angle(up, new Coords(direction)), Cross(up, NormalVector(new Coords(direction))).Z < 0).ToVector3();
    }

    /// <summary>
    /// Normal vector = (x / |V|, y / |V|, z / |V|)
    /// </summary>
    public static Coords NormalVector(Coords vector)
    {
        var lenght = Distance(vector, new Coords(0, 0, 0));
        vector.X /= lenght;
        vector.Y /= lenght;
        vector.Z /= lenght;

        return vector;
    }
    
    /// <summary>
    /// Distance = sqrt((x2 - x1)^2 + (y2 - y1)^2 + (z2 - z1)^2)
    /// </summary>
    public static float Distance(Coords point1, Coords point2)
    {
        return Mathf.Sqrt( Square(point1.X - point2.X) + Square(point1.Y - point2.Y) + Square(point1.Z - point2.Z));
    }

    /// <summary>
    /// Rotate vector and add to position.
    /// <code>
    /// t = (x + v.x, y + v.y, z + v.z)
    /// </code>
    /// </summary>
    /// <param name="position">Current position</param>
    /// <param name="vector">Vector to add</param>
    /// <returns>Returns translated vector</returns>
    public static Coords Translate(Coords position, Coords facing, Coords vector)
    {
        if (HolisticMath.Distance(new Coords(0, 0, 0), vector) <= 0) {
            return position;
        }
        
        var angle = HolisticMath.Angle(vector, facing);
        var worldAngle = HolisticMath.Angle(vector, new Coords(0, 1, 0)); // So we can go backwards
        var clockwise = HolisticMath.Cross(vector, facing).Z < 0;
        vector = HolisticMath.Rotate(vector, angle + worldAngle, clockwise);
        
        var xVal = position.X + vector.X;
        var yVal = position.Y + vector.Y;
        var zVal = position.Z + vector.Z;
        return new Coords(xVal, yVal, zVal);
    }

    /// <summary>
    ///  Angle = arc-cos((V dot W) / (|V| * |W|))
    /// </summary>
    /// <param name="vector1">V</param>
    /// <param name="vector2">W</param>
    /// <returns>Returns radians. For degrees multiply by 180/Mathf.PI</returns>
    public static float Angle(Coords vector1, Coords vector2)
    {
        var dotDivide = Dot(vector1, vector2) / (Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0,0 ), vector2));
        return Mathf.Acos(dotDivide);
    }

    /// <summary>
    /// <code>
    /// vX = x * cos(angle) - y * sin(angle)
    /// vY = y * sin(angle) + y * cos(angle)
    /// v = (vX, vY, 0)
    /// </code>
    /// </summary>
    /// <param name="vector">Vector v</param>
    /// <param name="angle">Angle in radians</param>
    /// <returns>Returns rotated /vector/ by /angle/</returns>
    public static Coords Rotate(Coords vector, float angle)
    {
        var xVal = vector.X * Mathf.Cos(angle) - vector.Y * Mathf.Sin(angle);
        var yVal = vector.X * Mathf.Sin(angle) + vector.Y * Mathf.Cos(angle);
        return new Coords(xVal, yVal, 0);
    }

    /// <summary>
    /// <code>
    /// vX = x * cos(angle) - y * sin(angle)
    /// vY = y * sin(angle) + y * cos(angle)
    /// v = (vX, vY, 0)
    /// </code>
    /// </summary>
    /// <param name="vector">Vector v</param>
    /// <param name="angle">Angle in radians</param>
    /// <param name="clockwise">Determine, if you want turn clockwise or not</param>
    /// <returns>Returns rotated /vector/ by /angle/</returns>
    public static Coords Rotate(Coords vector, float angle, bool clockwise)
    {
        if (clockwise) angle = 2 * Mathf.PI - angle;
        return Rotate(vector, angle);
    }
    
    /// <summary>
    /// <code>
    /// v = (vx, vy, vz)
    /// w = (wx, wy, wz)
    /// v x w = (vy * wz - vz * wy, vz * wx - vx * wz, vx * wy - vy * wx)
    /// </code>
    /// </summary>
    /// <param name="vector1">v - Direction, your currently facing</param>
    /// <param name="vector2">w - Direction, you will be facing</param>
    public static Coords Cross(Coords vector1, Coords vector2)
    {
        var xMult = vector1.Y * vector2.Z - vector1.Z * vector2.Y;
        var yMult = vector1.Z * vector2.X - vector1.X * vector2.Z;
        var zMult = vector1.X * vector2.Y - vector1.Y * vector2.X;
        return new Coords(xMult, yMult, zMult);
    }

    /// <summary>
    /// <code>
    /// a.b = ax * bx + ay * by + az * bz
    /// </code>
    /// </summary>
    /// <param name="vector1">a</param>
    /// <param name="vector2">b</param>
    public static float Dot(Coords vector1, Coords vector2)
    {
        return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
    }

    /// <summary>
    /// <code>
    /// v = ((A.x + v.X)*t, (A.y + v.y)*t, (A.z + v.z)*t)
    /// </code>
    /// </summary>
    public static Coords Lerp(Coords A, Coords B, float t)
    {
        t = Mathf.Clamp(t, 0, 1);
        var v = A - B;
        var x = A.X + v.X * t;
        var y = A.Y + v.Y * t;
        var z = A.Z + v.Z * t;
        return new Coords(x, y, z);
    }

    #region Privates
    private static float Square(float value)
    {
        return value * value;
    }
    #endregion
}