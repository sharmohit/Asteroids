using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Bullet Object
    /// </summary>
    public class Bullet : SpaceObject
    {
        public override void Awake()
        {
            base.Awake();

            Destroy(gameObject, 2f);
        }
    }
}