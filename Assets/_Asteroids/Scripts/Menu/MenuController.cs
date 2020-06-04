using UnityEngine;
using UnityEngine.SceneManagement;
using Asteroids.Events;

namespace Asteroids.Controller
{
    /// <summary>
    /// Controls Menu behaviour.
    /// </summary>
    public class MenuController : MonoBehaviour
    {
        private void OnEnable()
        {
            GameEvents.UIButtonClicked += UIButtonClicked_Handler;
        }

        private void OnDisable()
        {
            GameEvents.UIButtonClicked -= UIButtonClicked_Handler;
        }

        private void UIButtonClicked_Handler(string buttonName)
        {
            if(buttonName == Constants.LAUNCH_BUTTON)
            {
                SceneManager.LoadScene(Constants.GAME_SCENE);
            }
        }
    }
}