using UnityEngine;

namespace Assets.Movement
{
    public class MovementController
    {
        public float speed = 6.0F;

        public void Compute(GameObject camera)
        {
            var moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = camera.transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            camera.transform.position += moveDirection;
        }
    }
}