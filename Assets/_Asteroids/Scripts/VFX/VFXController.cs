using System.Collections;
using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.VFX
{
    /// <summary>
    /// VFXController controls VFX particle system.
    /// </summary>
    public class VFXController : MonoBehaviour
    {
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
        }

        private void ExplosionVFX(GameObject asteroid)
        {
            GameObject explosionVFX = ObjectPool.Instance.GetPooledObject(Constants.Tags.EXPLOSION_VFX);
            explosionVFX.transform.position = asteroid.transform.position;
            ParticleSystem particleSystem = explosionVFX.GetComponent<ParticleSystem>();
            particleSystem.GetComponent<Renderer>().sortingOrder = 4;
            explosionVFX.SetActive(true);
            StartCoroutine(DisableVFX(explosionVFX, particleSystem.main.duration));
        }

        private IEnumerator DisableVFX(GameObject vfxObj, float delay)
        {
            yield return new WaitForSeconds(delay);
            vfxObj.SetActive(false);
        }
    }
}