using System.Collections.Generic;
using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Level controller create and manage level object.
    /// </summary>
    public class LevelController : MonoBehaviour
    {
        [SerializeField] GameObject playerPrefab;

        private PlayerShip playerShip;
        private SaucerBig saucerBig;
        private SaucerSmall saucerSmall;

        private List<Asteroid> asteroids;

        private int currentLevel;

        private void OnEnable()
        {
            GameActions.DestroyAsteroid += DestroyAsteroid;
            GameActions.DestroyBigSaucer += DestroyBigSaucer;
            GameActions.DestroySmallSaucer += DestroySmallSaucer;
            GameActions.DestroyPlayer += DestroyPlayer;
            GameActions.LevelUp += LevelUp;
        }

        private void OnDisable()
        {
            GameActions.DestroyAsteroid -= DestroyAsteroid;
            GameActions.DestroyBigSaucer -= DestroyBigSaucer;
            GameActions.DestroySmallSaucer -= DestroySmallSaucer;
            GameActions.LevelUp -= LevelUp;
            GameActions.DestroyPlayer -= DestroyPlayer;
        }

        private void Start()
        {
            asteroids = new List<Asteroid>();

            GameActions.ShowUIScreen(UIScreen.HUD, true);
            LevelUp();

            SpawnPlayer();
            SpawnAsteroids(Constants.Tags.LARGE_ASTEROID, currentLevel);
        }

        private void SpawnAsteroids(string tag, int count)
        {
            GameObject asteroidObj = null;
            for (int i = 0; i < count; i++)
            {
                asteroidObj = ObjectPool.Instance.GetPooledObject(tag);
                asteroidObj.transform.position = Utilities.ConvertScreenToWorldPoint(
                    Utilities.GetRandomScreenPoint(Random.value,
                    Random.Range(Constants.Gameplay.ASTEROID_SPAWN_MIN_HEIGHT,
                    Constants.Gameplay.ASTEROID_SPAWN_MAX_HEIGHT)));
                Asteroid asteroid = asteroidObj.GetComponent<Asteroid>();
                asteroid.Direction = Utilities.GetRandomSpawnPoint().normalized;
                asteroidObj.SetActive(true);
                asteroids.Add(asteroid);
            }
        }

        private void SpawnAsteroidsAt(string tag, int count, Vector3 position)
        {
            GameObject asteroidObj = null;
            for (int i = 0; i < count; i++)
            {
                asteroidObj = ObjectPool.Instance.GetPooledObject(tag);
                asteroidObj.transform.position = position;
                Asteroid asteroid = asteroidObj.GetComponent<Asteroid>();
                asteroid.Direction = Utilities.GetRandomSpawnPoint().normalized;
                asteroidObj.SetActive(true);
                asteroids.Add(asteroid);
            }
        }

        private void SpawnPlayer()
        {
            GameObject playerObj = Instantiate(playerPrefab);
            playerShip = playerObj.GetComponent<PlayerShip>();
        }

        private void SpawnSaucerBig()
        {
            GameObject saucerObj = ObjectPool.Instance.GetPooledObject(Constants.Tags.BIG_SAUCER);
            saucerObj.SetActive(true);
            saucerBig = saucerObj.GetComponent<SaucerBig>();
            saucerObj.transform.position = Utilities.ConvertScreenToWorldPoint(
                Utilities.GetRandomScreenPoint(Random.value, Constants.Gameplay.SAUCER_BIG_SPAWN_HEIGHT));
            saucerBig.Direction = Utilities.GetRandomSpawnPoint().normalized;
        }

        private void SpawnSaucerSmall()
        {
            GameObject saucerObj = ObjectPool.Instance.GetPooledObject(Constants.Tags.SMALL_SAUCER);
            saucerObj.SetActive(true);
            saucerSmall = saucerObj.GetComponent<SaucerSmall>();
            saucerObj.transform.position = Utilities.ConvertScreenToWorldPoint(
                Utilities.GetRandomScreenPoint(Random.value, Constants.Gameplay.SAUCER_SMALL_SPAWN_HEIGHT));
            saucerSmall.Direction = Utilities.GetRandomSpawnPoint().normalized;
        }

        private void DestroyAsteroid(GameObject asteroidObject)
        {
            Asteroid asteroid = asteroidObject.GetComponent<Asteroid>();
            asteroids.Remove(asteroid);

            if (!string.IsNullOrEmpty(asteroid.nextAsteroidTag))
            {
                SpawnAsteroidsAt(asteroid.nextAsteroidTag, 2, asteroidObject.transform.position);
            }

            asteroidObject.SetActive(false);

            if (asteroids.Count == 0)
            {
                Invoke("NextLevel", Constants.Gameplay.NEXT_LEVEL_DELAY);
            }
        }

        private void DestroyPlayer()
        {
            if (playerShip.ShieldActivated)
                return;

            if(playerShip.extraLives > 0)
            {
                playerShip.GetComponent<SpriteRenderer>().enabled = false;
                playerShip.GetComponent<Collider2D>().enabled = false;
                Invoke("DeActivateShield", Constants.Gameplay.PLAYER_REVIVE_SHIELD_DURATION);
                playerShip.extraLives--;
                Invoke("RevivePlayer", Constants.Gameplay.PLAYER_REVIVE_DELAY);
            }
            else
            {
                CancelInvoke();
                Destroy(playerShip.gameObject);
                RemoveAllObjects();
                GameManager.Instance.GameCompleted();
            }
        }

        private void RevivePlayer()
        {
            playerShip.GetComponent<SpriteRenderer>().enabled = true;
            playerShip.ActivateShield();
        }

        private void DeActivateShield()
        {
            playerShip.DeActivateShield();
            playerShip.GetComponent<Collider2D>().enabled = true;
        }

        private void DestroyBigSaucer()
        {
            GameObject powerUpObj = ObjectPool.Instance.GetPooledObject(Constants.Tags.SHIELD_POWER_UP);
            powerUpObj.transform.position = saucerBig.transform.position;
            powerUpObj.SetActive(true);
            saucerBig.gameObject.SetActive(false);
        }

        private void DestroySmallSaucer()
        {
            GameObject powerUpObj = ObjectPool.Instance.GetPooledObject(Constants.Tags.SLOW_MO_POWER_UP);
            powerUpObj.transform.position = saucerSmall.transform.position;
            powerUpObj.SetActive(true);
            saucerSmall.gameObject.SetActive(false);
        }

        private void LevelUp()
        {
            currentLevel++;
            GameActions.LevelUpdate(currentLevel);

            GivePlayerExtraLife();
            SpawnSaucers();
        }

        private void NextLevel()
        {
            SpawnAsteroids(Constants.Tags.LARGE_ASTEROID, currentLevel);
        }

        private void RemoveAllObjects()
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].gameObject.SetActive(false);
            }

            asteroids.Clear();
        }

        private void SpawnSaucers()
        {
            if(currentLevel % Constants.Gameplay.SAUCER_SPAWN_LEVEL_MULTIPLE == 0)
            {
                if(currentLevel >= Constants.Gameplay.SMALL_SAUCER_SOLO_LEVEL)
                {
                    Invoke("SpawnSaucerSmall", 2f);
                }
                else
                {
                    Invoke("SpawnSaucerBig", 2f);
                    Invoke("SpawnSaucerSmall", 5f);
                }
            }
        }

        private void GivePlayerExtraLife()
        {
            if(currentLevel % Constants.Gameplay.EXTRA_LIFE_MULTIPLE == 0)
            {
                playerShip.extraLives++;
                GameActions.LivesUpdate(playerShip.extraLives);
            }
        }
    }
}