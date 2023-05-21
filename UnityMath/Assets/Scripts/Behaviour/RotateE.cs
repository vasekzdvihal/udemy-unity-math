using System;
using Math;
using UnityEngine;

namespace Behaviour
{
    public class RotateE : MonoBehaviour
    {
        public Vector3 eulerAngles;
        private Matrix rotationMatrix;
        private Coords axis;
        private float angle;
        private Coords quaternion;

        private void Start()
        {
            rotationMatrix = HolisticMath.GetRotationMatrix(
                eulerAngles.x * Mathf.Deg2Rad, false,
                eulerAngles.y * Mathf.Deg2Rad, false,
                eulerAngles.z * Mathf.Deg2Rad, false
            );
            angle = HolisticMath.GetRotationAxisAngle(rotationMatrix);
            axis = HolisticMath.GetRotationAxis(rotationMatrix, angle);
            quaternion = HolisticMath.Quaternion(axis, angle);
        }

        void Update()
        {
            this.transform.rotation *= new Quaternion(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
        }
    }
}
