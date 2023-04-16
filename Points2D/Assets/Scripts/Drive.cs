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
        // Vector where the tank is heading
        _direction = fuel.transform.position - this.transform.position;
        var directionNormal = HolisticMath.NormalVector(new Coords(_direction));
        _direction = directionNormal.ToVector3();
        var a = HolisticMath.Angle(new Coords(0, 1, 0), new Coords(_direction));
        var rotatedDirection = HolisticMath.Rotate(new Coords(0, 1, 0), a);
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