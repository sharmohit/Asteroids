using UnityEngine;
using Asteroids.Events;

namespace Asteroids.Controller
{
    /// <summary>
    /// Handle Game Input.
    /// </summary>
    public class GameInputController : MonoBehaviour
    {
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.PauseGame();
            }
        }
    }
}