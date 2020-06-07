using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Game Screen behaviour.
    /// </summary>
    public class GameScreenController : MonoBehaviour
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
            GameActions.ShowUIScreen(UIScreen.Result, true);
        }
    }
}