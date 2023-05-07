using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateLines : MonoBehaviour
{
    private Line _l1;
    private Line _l2;
    
    // Start is called before the first frame update
    void Start()
    {
        _l1 = new Line(new Coords(-100, 0, 0), new Coords(200, 150, 0));
        _l1.Draw(1, Color.green);

        _l2 = new Line(new Coords(0, -100, 0), new Coords(0, 200, 0));
        _l2.Draw(1, Color.red);

        var intersectT = _l1.IntersectsAt(_l2);
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = _l1.Lerp(intersectT).ToVector3();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
