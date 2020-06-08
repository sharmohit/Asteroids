using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [System.Serializable]
    public class ObjectPoolItem
    {
        public int count;
        public GameObject objectToPool;
    }

    /// <summary>
    /// Object pool mantain a pool of the objects required in the game.
    /// </summary>
    public class ObjectPool : Singleton<ObjectPool>
    {
        public List<ObjectPoolItem> itemsToPool;
        public List<GameObject> pooledObjects;

        private void Start()
        {
            pooledObjects = new List<GameObject>();

            foreach (ObjectPoolItem item in itemsToPool)
                for (int i = 0; i < item.count; i++)
                {
                    GameObject obj = Instantiate(item.objectToPool, transform);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                }
        }

        public GameObject GetPooledObject(string tag)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
                {
                    return pooledObjects[i];
                }
            }

            foreach (ObjectPoolItem item in itemsToPool)
            {
                if (item.objectToPool.tag == tag)
                {
                    GameObject obj = Instantiate(item.objectToPool, transform);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
            return null;
        }
    }
}