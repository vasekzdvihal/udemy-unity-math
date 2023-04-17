using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public GameObject fuel;
    public float speed = 5f;

    private Vector3 _direction;
    private const float StoppingDistance = 0.1f;

    void Start()
    {
        var t = this.transform;
        var up = new Coords(t.up);
        
        _direction = fuel.transform.position - t.position;
        var directionNormal = HolisticMath.NormalVector(new Coords(_direction));
        _direction = directionNormal.ToVector3();
        var a = HolisticMath.Angle(up, new Coords(_direction));
        
        var clockwise = HolisticMath.Cross(up, directionNormal).z < 0;

        var rotatedDirection = HolisticMath.Rotate(up, a, clockwise);
        this.transform.up = rotatedDirection.ToVector3();
    }
    
    void Update()
    {
        if (HolisticMath.Distance(new Coords(this.transform.position), new Coords(fuel.transform.position)) > StoppingDistance)
        {
            this.transform.position += _direction * (speed * Time.deltaTime);
        }
    }
}