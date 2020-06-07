using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls HUD Screen behaviour.
    /// </summary>
    public class HUDScreenController : MonoBehaviour
    {
        private void OnEnable()
        {
            GameActions.GameCompleted += GameCompleted;
        }

        private void OnDisable()
        {
            GameActions.GameCompleted -= GameCompleted;
        }

        private void GameCompleted()
        {
            GameActions.ShowUIScreen(UIScreen.HUD, false);
        }
    }
}