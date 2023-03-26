using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public GameObject fuel;
    public float speed = 0.01f;

    private Vector3 direction;
    private float stoppingDistance = 0.1f;

    void Start()
    {
        // Vector where the tank is heading
        this.direction = fuel.transform.position - this.transform.position;
    }
    
    void Update()
    {
        if (Vector3.Distance(this.transform.position, fuel.transform.position) > stoppingDistance)
        {
            this.transform.position += direction * speed;
        }
    }
}