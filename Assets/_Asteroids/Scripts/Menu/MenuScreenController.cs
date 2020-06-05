using UnityEngine;
using UnityEngine.SceneManagement;
using Asteroids.Events;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Menu Screen behaviour.
    /// </summary>
    public class MenuScreenController : MonoBehaviour
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
            if(buttonName == Constants.Buttons.LAUNCH_BUTTON)
            {
                SceneManager.LoadScene(Constants.Scenes.GAME_SCENE);
            }
        }
    }
}