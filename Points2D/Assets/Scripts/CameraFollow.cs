using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.15f;
    private Vector3 _currVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(
                player.position.x,
                player.position.y,
                transform.position.z),
            ref _currVelocity, smoothTime);
    }
}
