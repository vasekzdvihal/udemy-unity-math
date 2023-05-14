using UnityEngine;
using Plane = UnityEngine.Plane;
using UPlane = UnityEngine.Plane;

public class PlayRayIntersection : MonoBehaviour
{
    public GameObject shpere;
    public GameObject quad;
    public UPlane MPlane;
    
    void Start()
    {
        var vertices = quad.GetComponent<MeshFilter>().mesh.vertices;
        MPlane = new UPlane(quad.transform.TransformPoint(vertices[0]), quad.transform.TransformPoint(vertices[1]), quad.transform.TransformPoint(vertices[2]));
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var t = 0.0f;

            if (MPlane.Raycast(ray, out t)) {
                var hitPoint = ray.GetPoint(t);
                shpere.transform.position = hitPoint;
            }
        }
    }
}
