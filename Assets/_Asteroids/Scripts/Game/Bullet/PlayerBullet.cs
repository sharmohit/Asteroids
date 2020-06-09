using UnityEngine.SceneManagement;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// PlayerBullet Object
    /// </summary>
    public class PlayerBullet : Bullet
    {
        public override void OnEnable()
        {
            SceneManager.sceneUnloaded += SceneUnloaded;

            Health = MaxHealth;

            Invoke("DisableBullet", Constants.Gameplay.BULLET_LIFETIME);
        }

        public override void OnDisable()
        {
            SceneManager.sceneUnloaded -= SceneUnloaded;

            CancelInvoke("DisableBullet");
        }

        private void SceneUnloaded(Scene scene)
        {
            gameObject.SetActive(false);
        }
    }
}