using System;
using System.Collections;
using System.Collections.Generic;
using Objects;

public class Matrix
{
  private float[] _values;
  private int _rows;
  private int _columns;

  public Matrix(int rows, int columns, float[] values)
  {
    _rows = rows;
    _columns = columns;
    
    _values = new float[rows * columns];
    Array.Copy(values, _values, _rows * _columns);
  }

  public Coords AsCoords()
  {
    if (_rows == 4 && _columns == 4) {
      return new Coords(_values[0], _values[1], _values[2], _values[3]);
    }

    return null;
  }

  public static Matrix operator +(Matrix a, Matrix b)
  {
    if (a._rows != b._rows || a._columns != b._columns) {
      return null;
    }

    var result = new Matrix(a._rows, a._columns, a._values);
    var length = a._rows * a._columns;
    for (var i = 0; i < length; i++) {
      result._values[i] += b._values[i];
    }

    return result;
  }

  public static Matrix operator -(Matrix a, Matrix b)
  {
    if (a._rows != b._rows || a._columns != b._columns) {
      return null;
    }

    var result = new Matrix(a._rows, a._columns, a._values);
    var length = a._rows * a._columns;
    for (var i = 0; i < length; i++) {
      result._values[i] -= b._values[i];
    }

    return result;
  }

  public static Matrix operator *(Matrix a, Matrix b)
  {
    if (a._columns != b._rows) {
      return null;
    }

    var resultValues = new float[a._rows * b._columns];
    for (var i = 0; i < a._rows; i++) {
      for (var j = 0; j < b._columns; j++) {
        for (var k = 0; k < a._columns; k++) {
          resultValues[i * b._columns + j] += a._values[i * a._columns + k] * b._values[k * b._columns + j];
        }
      }
    }

    return new Matrix(a._rows, b._columns, resultValues);
  }

  public override string ToString()
  {
    var matrix = "";
    for (var r = 0; r < _rows; r++)
    {
      for (var c = 0; c < _columns; c++)
      {
        matrix += _values[r * _columns + c] + " ";
      }
      matrix += "\n";
    }
    return matrix;
  }
}
