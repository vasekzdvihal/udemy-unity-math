using UnityEngine;

public class Coords
{
    private float x;
    private float y;
    private float z;

    public Coords(float _X, float _Y)
    {
        this.x = _X;
        this.y = _Y;
        this.z = -1;
    }

    public override string ToString()
    {
        return $"X: {x} Y: {y} Z: {z}";
    }

    static public void DrawPoint(Coords position, float width, Color color)
    {
        GameObject line = new GameObject("Point_" + position.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = color;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(position.x - width / 3.0f, position.y - width / 3.0f, position.z));
        lineRenderer.SetPosition(1, new Vector3(position.x + width / 3.0f, position.y + width / 3.0f, position.z));
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
}
