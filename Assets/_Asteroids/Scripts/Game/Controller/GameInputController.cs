using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Controller
{
    /// <summary>
    /// Handle Game Input.
    /// </summary>
    public class GameInputController : MonoBehaviour
    {
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.GameState != GameState.Result)
            {
                GameManager.Instance.PauseGame();
            }
        }
    }
}