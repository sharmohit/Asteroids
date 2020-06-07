using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// PlayerShip Object Class 
    /// </summary>
    public class PlayerShip : SpaceObject
    {
        [SerializeField] GameObject bullet;
        [SerializeField] float forwardThrust = 7.0f;
        [SerializeField] float roatationalThrust = 3.5f;

        private Rigidbody2D rb;

        private float thrustInput;
        private float rotationInput;

        public override void Awake()
        {
            base.Awake();

            rb = GetComponent<Rigidbody2D>();
        }

        public override void Update()
        {
        }

        #region Commands
        public void MoveForward(float inputValue)
        {
            thrustInput = inputValue;
        }

        public void RotateShip(float inputValue)
        {
            rotationInput = inputValue;
        }

        public void Shoot()
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

        public void ActivateHyperspace()
        {
            transform.position = Utilities.GetRandomSpawnPoint();
        }
        #endregion

        #region Ship Movement
        private void AddForwardThrust()
        {
            if (thrustInput == 1)
            {
                Vector2 force = transform.up * forwardThrust;
                rb.AddForce(force);
            }
            thrustInput = 0;
        }

        private void AddRotationalThrust()
        {
            rb.AddTorque(roatationalThrust * -rotationInput);
            rotationInput = 0;
        }
        #endregion

        private void FixedUpdate()
        {
            AddForwardThrust();
            AddRotationalThrust();
        }
    }
}