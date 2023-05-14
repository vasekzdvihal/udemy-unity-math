using UnityEngine;
using System.Collections;
using Objects;
using UnityEngine.UI;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public Text energyAmt;
    public Text currentLocationText;
    public Vector3 currentLocation;

    void Start()
    {
        currentLocation = this.transform.position;
    }

    void Update()
    {
        if (float.Parse(energyAmt.text) <= 0) return;
        
        var translation = Input.GetAxis("Vertical") * speed;
        var rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        
        transform.position = HolisticMath.Translate(new Coords(transform.position), new Coords(transform.up),new Coords(0, translation, 0)).ToVector3();
        transform.up = HolisticMath.Rotate(new Coords(transform.up), -rotation * Mathf.Deg2Rad).ToVector3();
        
        energyAmt.text = (float.Parse(energyAmt.text) - Vector3.Distance(currentLocation, this.transform.position)) + "";
        currentLocation = this.transform.position;
        currentLocationText.text = currentLocation + "";
    }
}