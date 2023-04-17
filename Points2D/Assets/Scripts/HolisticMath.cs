using Unity.VisualScripting;
using UnityEngine;

public static class HolisticMath
{
    public static void LookAt(Transform transform, Vector3 target)
    {
        var up = new Coords(transform.up);
        var direction = target - transform.position;

        transform.up = Rotate(up, Angle(up, new Coords(direction)), Cross(up, NormalVector(new Coords(direction))).z < 0).ToVector3();
    }

    public static Coords LookAt(Coords forwardVector, Coords position, Coords focusPoint)
    {
        var direction = new Coords(focusPoint.x - position.x, focusPoint.y - position.y, position.z);
        var angle = HolisticMath.Angle(forwardVector, direction);
        var clockwise = Cross(forwardVector, direction).z < 0;
        return Rotate(forwardVector, angle, clockwise);
    }

    /// <summary>
    /// Normal vector = (x / |V|, y / |V|, z / |V|)
    /// </summary>
    public static Coords NormalVector(Coords vector)
    {
        var lenght = Distance(vector, new Coords(0, 0, 0));
        vector.x /= lenght;
        vector.y /= lenght;
        vector.z /= lenght;

        return vector;
    }
    
    /// <summary>
    /// Distance = sqrt((x2 - x1)^2 + (y2 - y1)^2 + (z2 - z1)^2)
    /// </summary>
    public static float Distance(Coords point1, Coords point2)
    {
        return Mathf.Sqrt( Square(point1.x - point2.x) + Square(point1.y - point2.y) + Square(point1.z - point2.z));
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
        var xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        var yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
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
        var xMult = vector1.y * vector2.z - vector1.z * vector2.y;
        var yMult = vector1.z * vector2.x - vector1.x * vector2.z;
        var zMult = vector1.x * vector2.y - vector1.y * vector2.x;
        return new Coords(xMult, yMult, zMult);
    }

    #region Privates
    private static float Dot(Coords vector1, Coords vector2)
    {
        return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
    }

    private static float Square(float value)
    {
        return value * value;
    }
    #endregion
}
