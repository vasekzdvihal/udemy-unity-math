using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float speed = 1f;
    
    void Update()
    {
        var translateX = Input.GetAxis("Horizontal") * speed;
        var translateY = Input.GetAxis("VerticalY") * speed;
        var translateZ = Input.GetAxis("Vertical") * speed;

        transform.position = new Vector3(transform.position.x + translateX, transform.position.y + translateY, transform.position.z + translateZ);
    }
}
