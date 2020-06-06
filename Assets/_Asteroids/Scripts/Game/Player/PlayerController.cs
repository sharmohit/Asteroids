using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Controls Player Behaviour
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject bullet;
        [SerializeField] float forwardThrust = 7.0f;
        [SerializeField] float roatationalThrust = 5.0f;

        private Rigidbody2D rb;
        private Vector2 minBound;
        private Vector2 maxBound;

        private float thrustInput;
        private float rotationalInput;

        private float lastTime;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            CalculateBounds(out minBound, out maxBound);

            lastTime = 0;
        }

        void Update()
        {
            rotationalInput = Input.GetAxis("Vertical");
            thrustInput = Input.GetAxis("Horizontal");

            if(Input.GetKeyDown(KeyCode.H))
            {
                ActivateHyperspace();
            }

            if(Input.GetKey(KeyCode.Space) && Time.time > lastTime + 0.25f)
            {
                lastTime = Time.time;
                Instantiate(bullet, transform.position, transform.rotation);
            }
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
                rb.AddForce(force);
            }
        }

        private void AddRotationalThrust()
        {
            rb.AddTorque(roatationalThrust * -thrustInput);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
        }

        private void OnBecameInvisible()
        {
            // Bound Check
            Vector2 newPosition = transform.position;
            if (transform.position.x < minBound.x)
                newPosition.x = maxBound.x;
            if (transform.position.y < minBound.y)
                newPosition.y = maxBound.y;
            if (transform.position.x > maxBound.x)
                newPosition.x = minBound.x;
            if (transform.position.y > maxBound.y)
                newPosition.y = minBound.y;

            transform.position = newPosition;
        }

        private void ActivateHyperspace()
        {
            Vector3 randomScreenPoint = new Vector3(Random.value, Random.value, 0);
            Vector3 randomSpawnPoint = Camera.main.ViewportToWorldPoint(randomScreenPoint);
            randomSpawnPoint.z = 0;
            transform.position = randomSpawnPoint;
        }

        private void CalculateBounds(out Vector2 min, out Vector2 max)
        {
            min = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
            max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        }
    }
}