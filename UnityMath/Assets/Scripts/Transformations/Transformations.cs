using UnityEngine;

namespace Math
{
    public class Transformations : MonoBehaviour
    {
        public GameObject[] points;
        public float angle;
        public Vector3 translation;
        
    
        // Start is called before the first frame update
        void Start()
        {
            // var position = new Coords(point.transform.position, 1);
            // point.transform.position = HolisticMath.Translate(position, new Coords(new Vector3(translation.x, translation.y, translation.z), 0)).ToVector3();

            foreach (var p in points) {
                var position = new Coords(p.transform.position, 1);
                p.transform.position = HolisticMath.Translate(position, new Coords(new Vector3(translation.x, translation.y, translation.z), 0)).ToVector3();
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
