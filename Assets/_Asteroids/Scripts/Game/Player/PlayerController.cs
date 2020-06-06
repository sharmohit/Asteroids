using UnityEngine;

namespace Asteroids.Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float forwardThrust = 7.0f;
        [SerializeField] float roatationalThrust = 4.0f;

        private Rigidbody2D rigidbody2D;
        private float thrustInput;
        private float rotationalInput;

        void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            rotationalInput = Input.GetAxis("Vertical");
            thrustInput = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            AddForwardThrust();
            AddRotationalThrust();
        }

        private void AddForwardThrust()
        {
            if(rotationalInput == 1)
            {
                Vector2 force = transform.up * forwardThrust;
                rigidbody2D.AddForce(force);
            }
        }

        private void AddRotationalThrust()
        {
            rigidbody2D.AddTorque(roatationalThrust * -thrustInput);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
        }
    }
}