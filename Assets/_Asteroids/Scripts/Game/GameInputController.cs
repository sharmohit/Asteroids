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

            // Temp Code for Testing
            if(Input.GetKeyDown(KeyCode.W))
            {
                GameManager.Instance.GameCompleted();
            }
        }
    }
}