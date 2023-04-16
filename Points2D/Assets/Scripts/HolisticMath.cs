using UnityEngine;

public static class HolisticMath
{
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
        var yVal = vector.y * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Coords(xVal, yVal, 0);
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
