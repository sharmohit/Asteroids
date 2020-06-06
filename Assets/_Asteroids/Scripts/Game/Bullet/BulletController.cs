using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Controls Bullet Behaviour
    /// </summary>
    public class BulletController : MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject, 2f);
        }

        void Update()
        {
            transform.Translate(Vector3.up * 10f * Time.deltaTime);
        }
    }
}