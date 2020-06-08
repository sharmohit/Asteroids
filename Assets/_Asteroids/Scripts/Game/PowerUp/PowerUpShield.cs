using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Shield Power up is based on powerup object.
    /// </summary>
    public class PowerUpShield : PowerUp
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == Constants.Tags.PLAYER_TAG)
            {
                GameActions.PowerUpShield();
                gameObject.SetActive(false);
            }
        }
    }
}