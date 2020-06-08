using UnityEngine;

namespace Asteroids.Gameplay {

    /// <summary>
    /// Saucer object based on space object.
    /// </summary>
    public class Saucer : SpaceObject
    {
        [SerializeField] GameObject bullet;
        [SerializeField] float minShootDelay = 1.0f;
        [SerializeField] float maxShootDelay = 2.0f;

        public int rewardScore;

        private float lastTime;

        private void Start()
        {
            Direction = Vector3.left;

            lastTime = 0;
        }

        public override void Update()
        {
            Move();

            if (Time.time > lastTime + Random.Range(minShootDelay, maxShootDelay))
            {
                lastTime = Time.time;
                Shoot();
            }

            CheckOutOfBounds();
        }

        public virtual void Shoot()
        {
            GameObject bulletObj = ObjectPool.Instance.GetPooledObject(Constants.Tags.ENEMY_BULLET_TAG);
            bulletObj.transform.position = transform.position;
            bulletObj.transform.rotation = transform.rotation;
            bulletObj.GetComponent<Bullet>().Direction = Vector3.down;
            bulletObj.SetActive(true);
        }
    }
}