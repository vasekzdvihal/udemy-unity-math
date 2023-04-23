﻿using UnityEngine;

public class Coords
{
  public float x;
  public float y;
  public float z;

  public Coords(float _X, float _Y)
  {
    this.x = _X;
    this.y = _Y;
    this.z = -1;
  }

  public Coords(float _X, float _Y, float _Z)
  {
    this.x = _X;
    this.y = _Y;
    this.z = _Z;
  }

  public Coords(Vector3 vector)
  {
    this.x = vector.x;
    this.y = vector.y;
    this.z = vector.z;
  }

  public override string ToString()
  {
    return $"X: {x} Y: {y} Z: {z}";
  }

  public Vector3 ToVector3()
  {
    return new Vector3(x, y, z);
  }

  public static void DrawPoint(Coords position, float width, Color color)
  {
    var line = new GameObject("Point_" + position.ToString());
    var lineRenderer = line.AddComponent<LineRenderer>();
    lineRenderer.material = new Material(Shader.Find("Unlit/Color"))
    {
      color = color
    };
    lineRenderer.positionCount = 2;
    lineRenderer.SetPosition(0, new Vector3(position.x - width / 3.0f, position.y - width / 3.0f, position.z));
    lineRenderer.SetPosition(1, new Vector3(position.x + width / 3.0f, position.y + width / 3.0f, position.z));
    lineRenderer.startWidth = width;
    lineRenderer.endWidth = width;
  }

  public static void DrawLine(Coords start, Coords end, float width, Color color)
  {
    var line = new GameObject($"Point_{start}_{end}");
    var lineRenderer = line.AddComponent<LineRenderer>();
    lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
    lineRenderer.material.color = color;
    lineRenderer.positionCount = 2;
    lineRenderer.SetPosition(0, new Vector3(start.x, start.y, start.z));
    lineRenderer.SetPosition(1, new Vector3(end.x, end.y, end.z));
    lineRenderer.startWidth = width;
    lineRenderer.endWidth = width;
  }
}