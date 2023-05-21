using Math;
using UnityEngine;

namespace Behaviour
{
    public class Transformations : MonoBehaviour
    {
        // Lines
        public float lineWidth = 0.02f;
        public Color lineColor = Color.green;
        
        public GameObject[] points;
        public GameObject center;
        public Vector3 angle;
        public Vector3 translation;
        public Vector3 scale;
        public Vector3 shear;


        
        void Start()
        {
            var cPos = this.center.transform.position;
            var center = new Vector3(cPos.x, cPos.y, cPos.z);
            
            // Translate();
            // Scale(center);
            // Rotate(center);
            // Shear();
            Reflect();
            
            ConnectPoints();
        }

        private void ConnectPoints()
        {
            foreach (var t in points) {
                foreach (var t1 in points) {
                    Coords.DrawLine(new Coords(t.transform.position), new Coords(t1.transform.position), lineWidth, lineColor);
                }
            }
        }

        private void Translate()
        {
            foreach (var point in points) {
                var position = new Coords(point.transform.position, 1);
                point.transform.position = HolisticMath.Translate(position, new Coords(new Vector3(translation.x, translation.y, translation.z), 0)).ToVector3();
            }
        }

        private void Scale(Vector3 c)
        {
            foreach (var p in points) {
                var position = new Coords(p.transform.position, 1);
                position = HolisticMath.Translate(position, new Coords(new Vector3(-c.x, -c.y, -c.z), 0));
                position = HolisticMath.Scale(position, scale.x, scale.y, scale.z);
                p.transform.position = HolisticMath.Translate(position, new Coords(new Vector3(c.x, c.y, c.z))).ToVector3();
            }
        }

        private void Rotate(Vector3 c)
        {
            foreach (var p in points) {
                var position = new Coords(p.transform.position, 1);
                position = HolisticMath.Translate(position, new Coords(new Vector3(-c.x, -c.y, -c.z), 0));
                position = HolisticMath.Rotate(position, angle.x, true, angle.y, true, angle.z, true);
                p.transform.position = HolisticMath.Translate(position, new Coords(new Vector3(c.x, c.y, c.z))).ToVector3();
            }
        }

        private void Shear()
        {
            foreach (var p in points) {
                var position = new Coords(p.transform.position, 1);
                p.transform.position = HolisticMath.Shear(position, shear.x, shear.y, shear.z).ToVector3();
            }
        }

        private void Reflect()
        {
            foreach (var p in points) {
                var position = new Coords(p.transform.position, 1);
                p.transform.position = HolisticMath.Reflect(position).ToVector3();
            }
        }
    }
}
