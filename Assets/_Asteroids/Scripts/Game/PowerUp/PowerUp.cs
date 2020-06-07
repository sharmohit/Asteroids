using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Power up object is based on space object.
    /// </summary>
    public class PowerUp : SpaceObject
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == Constants.Tags.PLAYER_TAG)
            {
                GameActions.PowerUpPickedUp();
                Destroy(gameObject);
            }
        }
    }
}