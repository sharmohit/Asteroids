using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Asteroid object.
    /// </summary>
    public class Asteroid : SpaceObject
    {
        public GameObject nextAsteroid;

        public override void Awake()
        {
            base.Awake();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == Constants.Tags.PLAYER_BULLET_TAG)
            {
                SpaceObject spaceObject = collision.GetComponent<SpaceObject>();
                health -= spaceObject.damage;

                if (health <= 0)
                {
                    GameActions.AddScore(10);
                    GameActions.DestroyAsteroid(gameObject);
                }
            }
            
            if(collision.tag == Constants.Tags.PLAYER_TAG)
            {
                GameActions.AddScore(10);
                GameActions.DestroyAsteroid(gameObject);
                //GameActions.DestroyPlayer();
            }
        }
    }
}