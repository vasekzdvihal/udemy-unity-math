using Math;
using UnityEngine;

namespace Behaviour
{
    public class Transformations : MonoBehaviour
    {
        public GameObject[] points;
        public GameObject center;
        public Vector3 angle;
        public Vector3 translation;
        public Vector3 scale;
        
        void Start()
        {
            var cPos = this.center.transform.position;
            var center = new Vector3(cPos.x, cPos.y, cPos.z);
            
            // Translate();
            // Scale(center);
            Rotate(center);
        }

        public void Translate()
        {
            foreach (var point in points) {
                var position = new Coords(point.transform.position, 1);
                point.transform.position = HolisticMath.Translate(position, new Coords(new Vector3(translation.x, translation.y, translation.z), 0)).ToVector3();
            }
        }

        public void Scale(Vector3 c)
        {
            foreach (var p in points) {
                var position = new Coords(p.transform.position, 1);
                position = HolisticMath.Translate(position, new Coords(new Vector3(-c.x, -c.y, -c.z), 0));
                position = HolisticMath.Scale(position, scale.x, scale.y, scale.z);
                p.transform.position = HolisticMath.Translate(position, new Coords(new Vector3(c.x, c.y, c.z))).ToVector3();
            }
        }

        public void Rotate(Vector3 c)
        {
            foreach (var p in points) {
                var position = new Coords(p.transform.position, 1);
                position = HolisticMath.Translate(position, new Coords(new Vector3(-c.x, -c.y, -c.z), 0));
                position = HolisticMath.Rotate(position, angle.x, true, angle.y, true, angle.z, true);
                p.transform.position = HolisticMath.Translate(position, new Coords(new Vector3(c.x, c.y, c.z))).ToVector3();
            }
        }
    }
}
