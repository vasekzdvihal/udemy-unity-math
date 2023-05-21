using UnityEngine;

namespace Behaviour
{
    public class Fly : MonoBehaviour
    {
        private const float Speed = 10.0f;
        private const float RotationSpeed = 100.0f;

        void Update()
        {
            float translation = Input.GetAxis("Vertical") * Speed;
            float rotation = Input.GetAxis("Horizontal") * RotationSpeed;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            Move(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }

        void Move(float x, float y, float z)
        {
            var worldTransform = transform.localToWorldMatrix;
            var planeWorldForward = worldTransform.GetColumn(2) * z;
            transform.position += new Vector3(planeWorldForward.x, planeWorldForward.y, planeWorldForward.z);
        }
    }
}
