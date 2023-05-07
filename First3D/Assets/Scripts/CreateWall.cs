using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    private Line _wall;
    private Line _ballPath;
    private Line _trajectory;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        _wall = new Line(new Coords(5, -2, 0), new Coords(0, 5, 0));
        _wall.Draw(1, Color.blue);

        _ballPath = new Line(new Coords(-6, 0, 0), new Coords(100, 0, 0));
        _ballPath.Draw(0.1f, Color.yellow);

        ball.transform.position = _ballPath.A.ToVector3();

        var t = _ballPath.IntersectsAt(_wall);
        var s = _wall.IntersectsAt(_ballPath);
        
        if (float.IsNaN(s) && float.IsNaN(t)) {
            Debug.Log("Lines do not intersect");
            return;
        }

        _trajectory = new Line(_ballPath.A, _ballPath.Lerp(t), Line.LineTypeEnum.Segment);
    }

    // Update is called once per frame
    void Update()
    {
        ball.transform.position = _trajectory.Lerp(Time.time).ToVector3();
    }
}
