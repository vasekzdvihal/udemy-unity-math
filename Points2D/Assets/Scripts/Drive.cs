using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public GameObject fuel;
    public float speed = 0.1f;

    private Vector3 _direction;
    private const float StoppingDistance = 0.1f;

    void Start()
    {
        // Vector where the tank is heading
        _direction = fuel.transform.position - this.transform.position;
        var directionNormal = HolisticMath.GetNormal(new Coords(_direction));
        _direction = directionNormal.ToVector3();
        var a = HolisticMath.Angle(new Coords(0, 1, 0), new Coords(_direction)) * 180.0f / Mathf.PI;
        Debug.Log($"Angle to fuel: {a}");
    }
    
    void Update()
    {
        if (HolisticMath.Distance(new Coords(this.transform.position), new Coords(fuel.transform.position)) > StoppingDistance)
        {
            this.transform.position += _direction * (speed * Time.deltaTime);
        }
    }
}