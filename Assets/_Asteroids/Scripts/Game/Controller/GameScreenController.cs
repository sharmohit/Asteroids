using UnityEngine;
using Asteroids.Events;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Game Screen behaviour.
    /// </summary>
    public class GameScreenController : MonoBehaviour
    {
        private void OnEnable()
        {
            GameEvents.GameCompleted += GameCompleted;
        }

        private void OnDisable()
        {
            GameEvents.GameCompleted -= GameCompleted;
        }

        private void GameCompleted()
        {
            GameEvents.ShowUIScreen(UIScreen.Result, true);
        }
    }
}