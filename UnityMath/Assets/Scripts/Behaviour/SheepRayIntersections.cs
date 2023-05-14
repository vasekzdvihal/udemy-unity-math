using UnityEngine;

public class SheepRayIntersections : MonoBehaviour
{
    public GameObject sheep;
    public GameObject quad;
    public GameObject[] fences;

    private UnityEngine.Plane mPlane;
    private Vector3[] fenceNormals;
    
    // Start is called before the first frame update
    void Start()
    {
        var vertices = quad.GetComponent<MeshFilter>().mesh.vertices;
        mPlane = new UnityEngine.Plane(quad.transform.TransformPoint(vertices[0]) + new Vector3(0, 0.3f, 0),
            quad.transform.TransformPoint(vertices[1]) + new Vector3(0, 0.3f, 0),
            quad.transform.TransformPoint(vertices[2]) + new Vector3(0, 0.3f, 0)
            );

        fenceNormals = new Vector3[fences.Length];
        for (var i = 0; i < fences.Length; i++) {
            var normal = fences[i].GetComponent<MeshFilter>().mesh.normals[0];
            fenceNormals[i] = fences[i].transform.TransformVector(normal);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var t = 0.0f;

            if (mPlane.Raycast(ray, out t)) {
                var hitPoint = ray.GetPoint(t);

                var inside = true;

                for (var i = 0; i < fences.Length; i++) {
                    var hitPointToFence = fences[i].transform.position - hitPoint;
                    inside = inside && Vector3.Dot(hitPointToFence, fenceNormals[i]) <= 0;
                }

                if (inside) {
                    sheep.transform.position = hitPoint;
                }
            }
        }
    }
}
