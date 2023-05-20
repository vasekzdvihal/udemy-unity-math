using Math;
using Objects;
using UnityEngine;

namespace Creators
{
    public class CreatePlaneHit : MonoBehaviour
    {
        public Transform A;
        public Transform B;
        public Transform C;
        public Transform D;
        public Transform E;

        private Plane _plane;
        private Line _l1;
    
        // Start is called before the first frame update
        void Start()
        {
            _plane = new Plane(new Coords(A.position), new Coords(B.position), new Coords(C.position));
            _l1 = new Line(new Coords(D.position), new Coords(E.position), LineTypeEnum.Ray);
            _l1.Draw(1, Color.green);

            for (var s = 0f; s <= 1; s += 0.05f) {
                for (var t = 0f; t <= 1; t += 0.05f) {
                    var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = _plane.Lerp(s, t).ToVector3();
                }
            }

            var interceptT = _l1.IntersectsAt(_plane);

            if (float.IsNaN(interceptT)) {
                Debug.Log("No intercept");
                return;
            }

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = _l1.Lerp(interceptT).ToVector3();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
