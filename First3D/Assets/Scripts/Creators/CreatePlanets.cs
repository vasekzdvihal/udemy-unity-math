using UnityEngine;

namespace Creators
{
    public class CreatePlanets : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            for (var i = 0; i < 2000; i++) {
                var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = Random.insideUnitSphere * 1000;
            }
        }
    }
}
