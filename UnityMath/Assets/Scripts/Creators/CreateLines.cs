using Math;
using UnityEngine;

namespace Creators
{
    public class CreateLines : MonoBehaviour
    {
        private Line _l1;
        private Line _l2;
    
        // Start is called before the first frame update
        void Start()
        {
            _l1 = new Line(new Coords(-100, 0, 0), new Coords(200, 150, 0));
            _l1.Draw(1, Color.green);

            _l2 = new Line(new Coords(-100,10, 0), new Coords(200, 150, 0));
            _l2.Draw(1, Color.red);

            var intersectT = _l1.IntersectsAt(_l2);
            var intersectS = _l2.IntersectsAt(_l1);

            if (float.IsNaN(intersectT) && float.IsNaN(intersectS)) {
                Debug.Log("Lines do not intersect");
                return;
            }

            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = _l1.Lerp(intersectT).ToVector3();
        }
    }

    class CreateLinesImpl : CreateLines
    {
    }
}
