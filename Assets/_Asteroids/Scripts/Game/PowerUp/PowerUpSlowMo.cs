using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// SlowMo Power up is based on powerup object.
    /// </summary>
    public class PowerUpSlowMo : PowerUp
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == Constants.Tags.PLAYER_TAG)
            {
                GameActions.PowerUpSlowMo();
                gameObject.SetActive(false);
            }
        }
    }
}