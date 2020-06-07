using UnityEngine;
using UnityEngine.SceneManagement;
using Asteroids.Actions;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Menu Screen behaviour.
    /// </summary>
    public class MenuScreenController : MonoBehaviour
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
            if(buttonName == Constants.Buttons.LAUNCH_BUTTON)
            {
                SceneManager.LoadScene(Constants.Scenes.GAME_SCENE);
            }
        }
    }
}