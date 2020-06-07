using UnityEngine;
using UnityEngine.SceneManagement;
using Asteroids.Actions;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Retry Button behaviour.
    /// </summary>
    public class RetryButtonController : MonoBehaviour
    {
        private void OnEnable()
        {
            GameActions.UIButtonClicked += UIButtonClicked;
        }

        private void OnDisable()
        {
            GameActions.UIButtonClicked -= UIButtonClicked;
        }

        private void UIButtonClicked(string buttonName)
        {
            if (buttonName == Constants.Buttons.RETRY_BUTTON)
            {
                SceneManager.LoadScene(Constants.Scenes.GAME_SCENE);
            }
        }
    }
}