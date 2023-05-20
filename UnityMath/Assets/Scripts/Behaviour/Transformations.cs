using Math;
using UnityEngine;

namespace Behaviour
{
    public class Transformations : MonoBehaviour
    {
        public GameObject[] points;
        public GameObject center;
        public float angle;
        public Vector3 translation;
        public Vector3 scale;
        
    
        // Start is called before the first frame update
        void Start()
        {
            var cPos = this.center.transform.position;
            var c = new Vector3(cPos.x, cPos.y, cPos.z);
            
            foreach (var p in points) {
                var position = new Coords(p.transform.position, 1);
                position = HolisticMath.Translate(position, new Coords(new Vector3(-c.x, -c.y, -c.z), 0));
                position = HolisticMath.Scale(position, scale.x, scale.y, scale.z);
                p.transform.position = HolisticMath.Translate(position, new Coords(new Vector3(c.x, c.y, c.z))).ToVector3();
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
