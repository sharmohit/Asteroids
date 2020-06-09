using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Audio
{
    /// <summary>
    /// Audio controller controls game audio events.
    /// </summary>
    public class AudioController : MonoBehaviour
    {
        private void OnEnable()
        {
            GameActions.GamePaused += GamePaused;
            GameActions.GameCompleted += GameCompleted;

            GameActions.DestroyAsteroid += DestroyAsteroid;
            GameActions.PlayerShipThrust += PlayerShipThrust;
            GameActions.PlayerShipShoot += PlayerShipShoot;
            GameActions.PowerUpSlowMo += PowerUpSlowMo;
            GameActions.PowerUpShield += PowerUpShield;
            GameActions.HyperspaceActivated += HyperspaceActivated;
            GameActions.DestroyBigSaucer += DestroyBigSaucer;
            GameActions.DestroySmallSaucer += DestroySmallSaucer;
            GameActions.UIButtonClicked += UIButtonClicked;
        }

        private void OnDisable()
        {
            GameActions.GamePaused -= GamePaused;
            GameActions.GameCompleted -= GameCompleted;

            GameActions.DestroyAsteroid -= DestroyAsteroid;
            GameActions.PlayerShipThrust -= PlayerShipThrust;
            GameActions.PlayerShipShoot -= PlayerShipShoot;
            GameActions.PowerUpSlowMo -= PowerUpSlowMo;
            GameActions.PowerUpShield -= PowerUpShield;
            GameActions.HyperspaceActivated -= HyperspaceActivated;
            GameActions.DestroyBigSaucer -= DestroyBigSaucer;
            GameActions.DestroySmallSaucer -= DestroySmallSaucer;
            GameActions.UIButtonClicked -= UIButtonClicked;
        }

        private void Start()
        {
            AudioManager.Instance.PlayBgMusic();
        }

        private void GamePaused(bool isPause)
        {
            if(isPause)
            {
                AudioManager.Instance.PauseBgMusic();
            }
            else
            {
                AudioManager.Instance.UnPauseBgMusic();
            }
        }

        private void GameCompleted()
        {
            AudioManager.Instance.StopLoopEffect();
        }

        private void DestroyAsteroid(GameObject asteroid)
        {
            if(asteroid.tag == Constants.Tags.LARGE_ASTEROID)
            {
                AudioManager.Instance.PlayEffect(Constants.Audio.EXPLOSION_LARGE);
            }
            else if (asteroid.tag == Constants.Tags.MEDIUM_ASTEROID)
            {
                AudioManager.Instance.PlayEffect(Constants.Audio.EXPLOSION_MEDIUM);
            }
            else if (asteroid.tag == Constants.Tags.SMALL_ASTEROID)
            {
                AudioManager.Instance.PlayEffect(Constants.Audio.EXPLOSION_SMALL);
            }
        }

        private void PlayerShipThrust(bool isMoving)
        {
            if(isMoving)
            {
                AudioManager.Instance.PlayLoopEffect(Constants.Audio.THRUST);
            }
            else
            {
                AudioManager.Instance.StopLoopEffect();
            }
        }

        private void PlayerShipShoot()
        {
            AudioManager.Instance.PlayEffect(Constants.Audio.SHOOT);
        }

        private void PowerUpSlowMo()
        {
            AudioManager.Instance.PlayEffect(Constants.Audio.SLOW_MO);
        }

        private void PowerUpShield()
        {
            AudioManager.Instance.PlayEffect(Constants.Audio.LIFE);
        }

        private void HyperspaceActivated()
        {
            AudioManager.Instance.PlayEffect(Constants.Audio.TELEPORT);
        }

        private void DestroyBigSaucer(GameObject obj)
        {
            AudioManager.Instance.PlayEffect(Constants.Audio.EXPLOSION_LARGE);
        }

        private void DestroySmallSaucer(GameObject obj)
        {
            AudioManager.Instance.PlayEffect(Constants.Audio.EXPLOSION_SMALL);
        }

        private void UIButtonClicked(string id)
        {
            AudioManager.Instance.PlayEffect(Constants.Audio.LIFE);
        }
    }
}