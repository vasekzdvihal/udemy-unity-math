using Math;
using UnityEngine;

namespace Behaviour
{
    public class RotateE : MonoBehaviour
    {
        void Update()
        {
            this.transform.forward = HolisticMath.Rotate(new Coords(this.transform.forward, 0),
                1 * Mathf.Deg2Rad, false,
                1 * Mathf.Deg2Rad, false,
                1 * Mathf.Deg2Rad, false)
                .ToVector3();
        }
    }
}
