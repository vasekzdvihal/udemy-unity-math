using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float speed = 1f;
    
    void Update()
    {
        var rotationX = Input.GetAxis("Vertical") * rotationSpeed;
        var rotationY = Input.GetAxis("Horizontal") * rotationSpeed;
        var rotationZ = Input.GetAxis("HorizontalZ") * rotationSpeed;
        var translateZ = Input.GetAxis("VerticalY") * speed;

        // Move object
        transform.Translate(0, 0, translateZ);
        
        // Rotate object
        transform.Rotate(rotationX, rotationY, rotationZ);
    }
}
