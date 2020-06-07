using UnityEngine;
using UnityEngine.SceneManagement;
using Asteroids.Actions;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Quit Button behaviour.
    /// </summary>
    public class QuitButtonController : MonoBehaviour
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
            if (buttonName == Constants.Buttons.QUIT_BUTTON)
            {
                SceneManager.LoadScene(Constants.Scenes.MENU_SCENE);
            }
        }
    }
}