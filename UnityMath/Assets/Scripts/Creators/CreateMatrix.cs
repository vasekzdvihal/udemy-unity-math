using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMatrix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float[] mValues = { 1, 2, 3, 4, 5, 6 };
        var m = new Matrix(2, 3, mValues);

        float[] nValues = { 1, 2, 3, 4, 5, 6 };
        var n = new Matrix(3, 2, nValues);
        
        var answer = m * n;
        
        Debug.Log(m + "\n" + n + "\n" + answer);
    }
}
