using UnityEngine;
using Asteroids.Events;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Pause behaviour.
    /// </summary>
    public class PauseScreenController : MonoBehaviour
    {
        private void OnEnable()
        {
            GameEvents.GamePaused += GamePaused;
        }

        private void OnDisable()
        {
            GameEvents.GamePaused -= GamePaused;
        }

        private void GamePaused(bool isPause)
        {
            GameEvents.ShowUIScreen(UIScreen.Pause, isPause);
        }
    }
}