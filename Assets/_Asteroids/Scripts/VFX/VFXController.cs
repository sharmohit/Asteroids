using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.VFX
{
    /// <summary>
    /// VFXController controls VFX particle system.
    /// </summary>
    public class VFXController : MonoBehaviour
    {
        // Holds the explosionVFXObjects returned from Object Pool. 
        private List<GameObject> explosionVFXObjects;

        private void OnEnable()
        {
            GameActions.DestroyAsteroid += ExplosionVFX;
            GameActions.DestroyBigSaucer += ExplosionVFX;
            GameActions.DestroySmallSaucer += ExplosionVFX;
        }

        private void OnDisable()
        {
            GameActions.DestroyAsteroid -= ExplosionVFX;
            GameActions.DestroyBigSaucer -= ExplosionVFX;
            GameActions.DestroySmallSaucer -= ExplosionVFX;

            RemoveAllVFX();
        }

        private void Start()
        {
            explosionVFXObjects = new List<GameObject>();
        }

        private void RemoveAllVFX()
        {
            for (int i = 0; i < explosionVFXObjects.Count; i++)
            {
                if(explosionVFXObjects[i] != null)
                {
                    explosionVFXObjects[i].SetActive(false);
                }
            }

            explosionVFXObjects.Clear();
        }

        private void ExplosionVFX(GameObject asteroid)
        {
            GameObject explosionVFX = ObjectPool.Instance.GetPooledObject(Constants.Tags.EXPLOSION_VFX);
            explosionVFX.transform.position = asteroid.transform.position;
            ParticleSystem particleSystem = explosionVFX.GetComponent<ParticleSystem>();
            particleSystem.GetComponent<Renderer>().sortingOrder = 4;
            explosionVFX.SetActive(true);
            explosionVFXObjects.Add(explosionVFX);
            StartCoroutine(DisableVFX(explosionVFX, particleSystem.main.duration));
        }

        private IEnumerator DisableVFX(GameObject vfxObj, float delay)
        {
            yield return new WaitForSeconds(delay);
            vfxObj.SetActive(false);
            explosionVFXObjects.Remove(vfxObj);
        }
    }
}