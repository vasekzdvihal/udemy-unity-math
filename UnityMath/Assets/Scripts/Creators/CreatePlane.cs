using Math;
using UnityEngine;
using Plane = Math.Plane;

namespace Creators
{
    public class CreatePlane : MonoBehaviour
    {
        public Transform a;
        public Transform b;
        public Transform c;
        public float density = 0.1f;
        public int size = 1;
    
        private Plane plane;

        private void Start()
        {
            plane = new Plane(new Coords(a.position), new Coords(b.position), new Coords(c.position));

            for (float s = 0; s < size; s += density) {
                for (float t = 0; t < size; t += density)
                {
                    var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = plane.Lerp(s, t).ToVector3();
                }
            }
        }
    }
}