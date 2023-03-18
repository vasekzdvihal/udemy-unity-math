using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // everything except layer 10
        // int layerMask = 1 << 10;
        // layerMask = ~layerMask;
        
        // just layer 9 and 10
        int layerMask = (1 << 10) | (1 << 9);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("Missed");
        }
    }
}
