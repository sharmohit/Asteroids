using UnityEngine;
using UnityEngine.UI;
using Asteroids.Events;

namespace Asteroids.UI
{
    /// <summary>
    /// Handle Game Screen UI Elements.
    /// </summary>
    public class GameScreenUI : MonoBehaviour
    {
        [SerializeField] GameObject pauseScreen;
        [SerializeField] GameObject resultScreen;

        private void OnEnable()
        {
            GameEvents.ShowUIScreen += ShowUIScreen;
        }

        private void OnDisable()
        {
            GameEvents.ShowUIScreen -= ShowUIScreen;
        }

        private void ShowUIScreen(UIScreen screen, bool isActive)
        {
            if (screen == UIScreen.Pause)
            {
                pauseScreen.SetActive(isActive);
            }
            else if(screen == UIScreen.Result)
            {
                resultScreen.SetActive(isActive);
            }
        }
    }
}