using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// PlayerBullet Object
    /// </summary>
    public class PlayerBullet : Bullet
    {
        public override void OnEnable()
        {
            Invoke("DisableBullet", Constants.Gameplay.BULLET_LIFETIME);
        }

        public override void OnDisable()
        {
            CancelInvoke("DisableBullet");
        }
    }
}