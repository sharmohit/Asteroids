using UnityEngine;

namespace Asteroids
{
    /// <summary>
    /// Utilities provide helper methods.
    /// </summary>
    public static class Utilities
    {
        public static Vector3 GetRandomScreenPoint(float x, float y, float z = 0)
        {
            return new Vector3(x, y, z);
        }

        public static Vector3 ConvertScreenToWorldPoint(Vector3 screenPoint)
        {
            Vector3 worldPoint = Camera.main.ViewportToWorldPoint(screenPoint);
            worldPoint.z = 0;

            return worldPoint;
        }

        public static Vector3 GetRandomSpawnPoint()
        {
            Vector3 randomScreenPoint = GetRandomScreenPoint(Random.value, Random.value, 0);

            return ConvertScreenToWorldPoint(randomScreenPoint);
        }
    }
}