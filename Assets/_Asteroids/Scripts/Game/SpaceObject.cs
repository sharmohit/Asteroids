using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Base classs for Space Objects
    /// </summary>
    public class SpaceObject : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 2.0f;
        [SerializeField] bool canRotate;
        [SerializeField] float rotateSpeed = 40.0f;
        [SerializeField] Space translateSpace = Space.World;

        public float damage = 25.0f;
        public float health = 100.0f;
        
        public Vector3 Direction { get; set; }

        private Vector2 minBound;
        private Vector2 maxBound;

        public virtual void Awake()
        {
            Direction = Vector3.up;

            CalculateBounds(out minBound, out maxBound);
        }

        public virtual void Update()
        {
            Move();
            if (canRotate)
                Rotate();
        }

        public virtual void Move()
        {
            transform.Translate(Direction * moveSpeed * Time.deltaTime, translateSpace);
        }

        public virtual void Rotate()
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }

        private void OnBecameInvisible()
        {
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

        private void CalculateBounds(out Vector2 min, out Vector2 max)
        {
            min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        }
    }
}