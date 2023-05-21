using Math;
using UnityEngine;

namespace Behaviour
{
    public class AxisRotate : MonoBehaviour
    {
        public GameObject[] points;
        public Vector3 angle;
    
        // Start is called before the first frame update
        void Start()
        {
            angle = angle * Mathf.Deg2Rad;
            foreach (var p in points) {
                var position = new Coords(p.transform.position, 1);
                p.transform.position = HolisticMath.Rotate(position, angle.x, true, angle.y, true, angle.z, true).ToVector3();
            }

            var rot = HolisticMath.GetRotationMatrix(angle.x, true, angle.y, true, angle.z, true);
            var rotAngle = HolisticMath.GetRotationAxisAngle(rot);
            var rotAxis = HolisticMath.GetRotationAxis(rot, rotAngle);
            
            Debug.Log($"{rotAngle * Mathf.Rad2Deg} about {rotAxis}");
            Coords.DrawLine(new Coords(0, 0, 0), rotAxis * 5, 0.1f, Color.black);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
