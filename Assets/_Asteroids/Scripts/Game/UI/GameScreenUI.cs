using UnityEngine;
using UnityEngine.UI;
using Asteroids.Actions;

namespace Asteroids.UI
{
    /// <summary>
    /// Handle Game Screen UI Elements.
    /// </summary>
    public class GameScreenUI : MonoBehaviour
    {
        [SerializeField] GameObject pauseScreen;
        [SerializeField] GameObject hudScreen;
        [SerializeField] GameObject resultScreen;

        private void OnEnable()
        {
            GameActions.ShowUIScreen += ShowUIScreen;
        }

        private void OnDisable()
        {
            GameActions.ShowUIScreen -= ShowUIScreen;
        }

        private void ShowUIScreen(UIScreen screen, bool isActive)
        {
            if (screen == UIScreen.Pause)
            {
                pauseScreen.SetActive(isActive);
            }
            else if(screen == UIScreen.HUD)
            {
                hudScreen.SetActive(isActive);
            }
            else if (screen == UIScreen.Result)
            {
                resultScreen.SetActive(isActive);
            }
        }
    }
}