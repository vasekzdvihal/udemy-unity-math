using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    private readonly Vector2 _yMovement = new Vector2(0, 1);
    private readonly Vector2 _xMovement = new Vector2(1, 0);
    private float _speed = 0.1f;
    
    void Update()
    {
        var position = this.transform.position;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            position.x += _yMovement.x * _speed;
            position.y += _yMovement.y * _speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            position.x += -_yMovement.x * _speed;
            position.y += -_yMovement.y * _speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            position.x += -_xMovement.x * _speed;
            position.y += -_xMovement.y * _speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            position.x += _xMovement.x * _speed;
            position.y += _xMovement.y * _speed;
        }
        
        this.transform.position = position;
    }
}