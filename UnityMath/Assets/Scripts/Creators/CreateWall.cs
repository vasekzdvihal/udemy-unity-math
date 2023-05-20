using Math;
using Objects;
using UnityEngine;

namespace Creators
{
  public class CreateWall : MonoBehaviour
  {
    public GameObject ball;
    
    private Line _wall;
    private Line _ballPath;
    private Vector3 _pathNormal;
    private Line _trajectory;

    // Start is called before the first frame update
    void Start()
    {
      _wall = new Line(new Coords(5, -2, 0), new Coords(0, 5, 0));
      _wall.Draw(1, Color.blue);

      _ballPath = new Line(new Coords(-6, 2, 0), new Coords(100, -20, 0));
      _ballPath.Draw(0.1f, Color.yellow);

      ball.transform.position = _ballPath.A.ToVector3();

      //ball path wall intersection
      var t = _ballPath.IntersectsAt(_wall);
      var s = _wall.IntersectsAt(_ballPath);
        
      if (!float.IsNaN(t)  && !float.IsNaN(s)) {
        _trajectory = new Line(_ballPath.A, _ballPath.Lerp(t), LineTypeEnum.Segment);
      }
    }

    // Update is called once per frame
    void Update()
    {
      if (Time.time <= 1) {
        ball.transform.position = _trajectory.Lerp(Time.time).ToVector3();
      }
      else {
        ball.transform.position += _trajectory.Reflect(Coords.Perp(_wall.v)).ToVector3() * (Time.deltaTime * 5);
      }
    }
  }
}
