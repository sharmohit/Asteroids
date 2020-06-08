using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// PlayerShip Object Class 
    /// </summary>
    public class PlayerShip : SpaceObject
    {
        [SerializeField] GameObject shield;
        [SerializeField] GameObject bullet;
        [SerializeField] float forwardThrust = 7.0f;
        [SerializeField] float roatationalThrust = 3.5f;

        public bool ShieldActivated { get; private set; }

        public int extraLives;

        private Rigidbody2D rb;

        private float thrustInput;
        private float rotationInput;

        public override void Awake()
        {
            base.Awake();

            rb = GetComponent<Rigidbody2D>();
        }

        public override void OnEnable()
        {
            GameActions.PowerUpShield += PowerUpShield;
        }

        public override void OnDisable()
        {
            GameActions.PowerUpShield -= PowerUpShield;
        }

        private void Start()
        {
            GameActions.LivesUpdate(extraLives);
        }

        public override void Update()
        {
            CheckOutOfBounds();
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
            GameObject bulletObj = ObjectPool.Instance.GetPooledObject(Constants.Tags.PLAYER_BULLET_TAG);
            bulletObj.transform.position = transform.position;
            bulletObj.transform.rotation = transform.rotation;
            bulletObj.SetActive(true);
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

        private void PowerUpShield()
        {
            extraLives += Constants.Gameplay.EXTRA_LIFE_POWER_UP_COUNT;
            GameActions.LivesUpdate(extraLives);
            ActivateShield();
            Invoke("DeActivateShield", Constants.Gameplay.POWER_UP_DURATION);
        }

        public void ActivateShield()
        {
            shield.SetActive(true);
            ShieldActivated = true;
        }

        public void DeActivateShield()
        {
            shield.SetActive(false);
            ShieldActivated = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == Constants.Tags.ENEMY_BULLET_TAG)
            {
                SpaceObject spaceObject = collision.GetComponent<SpaceObject>();
                health -= spaceObject.damage;
                collision.gameObject.SetActive(false);

                if (health <= 0)
                {
                    GameActions.DestroyPlayer();
                }
            }
        }
    }
}