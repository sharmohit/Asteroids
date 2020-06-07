using UnityEngine;
using UnityEngine.UI;
using Asteroids.Actions;

namespace Asteroids.UI
{
    /// <summary>
    /// Handle Pause Screen UI Elements.
    /// </summary>
    public class PauseScreenUI : MonoBehaviour
    {
        [SerializeField] Button retryBtn;
        [SerializeField] Button quitBtn;

        private void OnEnable()
        {
            retryBtn.onClick.AddListener(RetryClicked);
            quitBtn.onClick.AddListener(QuitClicked);
        }

        private void OnDisable()
        {
            retryBtn.onClick.RemoveListener(RetryClicked);
            quitBtn.onClick.RemoveListener(QuitClicked);
        }

        private void RetryClicked()
        {
            GameActions.UIButtonClicked(Constants.Buttons.RETRY_BUTTON);
        }

        private void QuitClicked()
        {
            GameActions.UIButtonClicked(Constants.Buttons.QUIT_BUTTON);
        }
    }
}