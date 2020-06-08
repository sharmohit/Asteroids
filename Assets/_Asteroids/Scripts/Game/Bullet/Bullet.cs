using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Bullet Object
    /// </summary>
    public class Bullet : SpaceObject
    {
        public override void OnEnable()
        {
            base.OnEnable();

            Invoke("DisableBullet", Constants.Gameplay.BULLET_LIFETIME);
        }

        public override void OnDisable()
        {
            base.OnDisable();

            CancelInvoke("DisableBullet");
        }

        private void DisableBullet()
        {
            gameObject.SetActive(false);
        }
    }
}