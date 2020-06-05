using UnityEngine;
using UnityEngine.SceneManagement;
using Asteroids.Events;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Retry Button behaviour.
    /// </summary>
    public class RetryButtonController : MonoBehaviour
    {
        private void OnEnable()
        {
            GameEvents.UIButtonClicked += UIButtonClicked;
        }

        private void OnDisable()
        {
            GameEvents.UIButtonClicked -= UIButtonClicked;
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