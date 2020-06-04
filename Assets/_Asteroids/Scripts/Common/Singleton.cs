using UnityEngine;

namespace Asteroids
{
    /// <summary>
    /// Singleton class to help other classes be singleton by inheriting it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<T>();
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(GetComponent<T>());
            }
        }
    }
}