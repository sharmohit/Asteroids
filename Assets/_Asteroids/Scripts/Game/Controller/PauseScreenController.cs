using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Pause behaviour.
    /// </summary>
    public class PauseScreenController : MonoBehaviour
    {
        private void OnEnable()
        {
            GameActions.GamePaused += GamePaused;
        }

        private void OnDisable()
        {
            GameActions.GamePaused -= GamePaused;
        }

        private void GamePaused(bool isPause)
        {
            GameActions.ShowUIScreen(UIScreen.Pause, isPause);
        }
    }
}