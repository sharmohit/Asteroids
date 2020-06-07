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

        private PlayerShip playerShip;
        private List<Asteroid> asteroids;

        private int currentLevel;

        private void OnEnable()
        {
            GameActions.DestroyAsteroid += DestroyAsteroid;
            GameActions.LevelUp += LevelUp;
        }

        private void OnDisable()
        {
            GameActions.DestroyAsteroid -= DestroyAsteroid;
            GameActions.LevelUp -= LevelUp;
        }

        private void Start()
        {
            asteroids = new List<Asteroid>();

            LevelUp();

            SpawnPlayer();
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
                Invoke("NextLevel", 1.2f);
            }
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
    }
}