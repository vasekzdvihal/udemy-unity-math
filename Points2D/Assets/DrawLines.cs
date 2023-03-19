using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    Coords point = new Coords(10, 20);
    
    
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log(point.ToString());
       Coords.DrawPoint(point, 3, Color.yellow);
       
       Coords.DrawPoint(new Coords(0, 0), 2, Color.grey); // Origin
       Coords.DrawLine(new Coords(0, 100), new Coords(0, -100), 1, Color.green); // Y axis
       Coords.DrawLine(new Coords(160, 0), new Coords(-160, 0), 1, Color.red); // X axis
    }
}
