using Math;
using UnityEngine;
using Plane = Math.Plane;

namespace Creators
{
    public class CreateSolidWall : MonoBehaviour
    {
        public Transform A;
        public Transform B;
        public Transform C;
        public Transform D;
        public Transform E;
        public GameObject Ball;

        private Plane _wall;
        private Line _ballPath;
        private Line _trajectory;
    
        void Start()
        {
            _wall = new Plane(new Coords(A.position), new Coords(B.position), new Coords(C.position));

            // Draw wall using spheres
            for (var s = 0f; s <= 1; s += 0.05f) {
                for (var t = 0f; t <= 1; t += 0.05f) {
                    var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = _wall.Lerp(s, t).ToVector3();
                }
            }

            // Draw ball path
            _ballPath = new Line(new Coords(D.position), new Coords(E.position), LineTypeEnum.Ray);
            _ballPath.Draw(0.1f, Color.green);

            // Move ball to start of ball path
            Ball.transform.position = _ballPath.A.ToVector3();
        
            // Ball X Path wall intersection
            var intersectT = _ballPath.IntersectsAt(_wall);
            if (!float.IsNaN(intersectT)) {
                _trajectory = new Line(_ballPath.A, _ballPath.Lerp(intersectT), LineTypeEnum.Segment);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time <= 1) {
                Ball.transform.position = _trajectory.Lerp(Time.time).ToVector3();
            }
            else {
                Ball.transform.position += _trajectory.Reflect(HolisticMath.Cross(_wall.v, _wall.u)).ToVector3() * (Time.deltaTime * 10);
            }
        }
    }
}
