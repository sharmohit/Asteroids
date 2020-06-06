using UnityEngine;
using UnityEngine.SceneManagement;
using Asteroids.Events;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Quit Button behaviour.
    /// </summary>
    public class QuitButtonController : MonoBehaviour
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
            if (buttonName == Constants.Buttons.QUIT_BUTTON)
            {
                SceneManager.LoadScene(Constants.Scenes.MENU_SCENE);
            }
        }
    }
}