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
        [SerializeField] GameObject asteroidPrefab;
        [SerializeField] GameObject saucerBigPrefab;
        [SerializeField] GameObject powerUpPrefab;

        private PlayerShip playerShip;
        private SaucerBig saucerBig;
        private List<Asteroid> asteroids;

        private int currentLevel;

        private void OnEnable()
        {
            GameActions.DestroyAsteroid += DestroyAsteroid;
            GameActions.DestroyBigSaucer += DestroyBigSaucer;
            GameActions.DestroyPlayer += DestroyPlayer;
            GameActions.LevelUp += LevelUp;
        }

        private void OnDisable()
        {
            GameActions.DestroyAsteroid -= DestroyAsteroid;
            GameActions.DestroyBigSaucer -= DestroyBigSaucer;
            GameActions.LevelUp -= LevelUp;
            GameActions.DestroyPlayer -= DestroyPlayer;
        }

        private void Start()
        {
            asteroids = new List<Asteroid>();

            GameActions.ShowUIScreen(UIScreen.HUD, true);
            LevelUp();

            SpawnPlayer();
            SpawnSaucerBig();
            SpawnAsteroids(asteroidPrefab, currentLevel);
        }

        private void SpawnAsteroids(GameObject prefab, int count)
        {
            GameObject asteroidObj = null;
            for (int i = 0; i < count; i++)
            {
                asteroidObj = Instantiate(prefab);
                asteroidObj.transform.position = Utilities.ConvertScreenToWorldPoint(Utilities.GetRandomScreenPoint(Random.value, 0.8f));
                Asteroid asteroid = asteroidObj.GetComponent<Asteroid>();
                asteroid.Direction = Utilities.GetRandomSpawnPoint().normalized;
                asteroids.Add(asteroid);
            }
        }

        private void SpawnAsteroidsAt(GameObject prefab, int count, Vector3 position)
        {
            GameObject asteroidObj = null;
            for (int i = 0; i < count; i++)
            {
                asteroidObj = Instantiate(prefab);
                asteroidObj.transform.position = position;
                Asteroid asteroid = asteroidObj.GetComponent<Asteroid>();
                asteroid.Direction = Utilities.GetRandomSpawnPoint().normalized;
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
            GameObject saucerObj = Instantiate(saucerBigPrefab);
            saucerBig = saucerObj.GetComponent<SaucerBig>();
            saucerObj.transform.position = Utilities.ConvertScreenToWorldPoint(Utilities.GetRandomScreenPoint(Random.value, 0.6f));
            saucerBig.Direction = Utilities.GetRandomSpawnPoint().normalized;
        }

        private void DestroyAsteroid(GameObject asteroidObject)
        {
            Asteroid asteroid = asteroidObject.GetComponent<Asteroid>();
            asteroids.Remove(asteroid);

            if (asteroid.nextAsteroid != null)
            {
                SpawnAsteroidsAt(asteroid.nextAsteroid, 2, asteroidObject.transform.position);
            }

            Destroy(asteroidObject);

            if (asteroids.Count == 0)
            {
                Invoke("NextLevel", Constants.Gameplay.NEXT_LEVEL_DELAY);
            }
        }

        private void DestroyPlayer()
        {
            playerShip.gameObject.SetActive(false);
            if(playerShip.extraLives > 0)
            {
                playerShip.extraLives--;
                Invoke("RevivePlayer", Constants.Gameplay.PLAYER_REVIVE_DELAY);
            }
            else
            {
                CancelInvoke("RevivePlayer");
                Destroy(playerShip.gameObject);
                RemoveAllObjects();
                GameManager.Instance.GameCompleted();
            }
        }

        private void DestroyBigSaucer()
        {
            GameObject powerUpObj = Instantiate(powerUpPrefab);
            powerUpObj.transform.position = saucerBig.transform.position;
            Destroy(saucerBig.gameObject);
        }

        private void RevivePlayer()
        {
            playerShip.gameObject.SetActive(true);
        }

        private void LevelUp()
        {
            currentLevel++;
            GameActions.LevelUpdate(currentLevel);
        }

        private void NextLevel()
        {
            SpawnAsteroids(asteroidPrefab, currentLevel);
        }

        private void RemoveAllObjects()
        {
            CancelInvoke("NextLevel");

            for (int i = 0; i < asteroids.Count; i++)
            {
                Destroy(asteroids[i].gameObject);
            }

            asteroids.Clear();
        }
    }
}