using UnityEngine;
using UnityEngine.UI;
using Asteroids.Events;

namespace Asteroids.UI
{
    /// <summary>
    /// Handle Menu Screen UI Elements.
    /// </summary>
    public class MenuScreenUI : MonoBehaviour
    {
        [SerializeField] Button launchBtn;

        private void OnEnable()
        {
            launchBtn.onClick.AddListener(LaunchClicked);
        }

        private void OnDisable()
        {
            launchBtn.onClick.RemoveListener(LaunchClicked);
        }

        private void LaunchClicked()
        {
            GameEvents.UIButtonClicked(Constants.Buttons.LAUNCH_BUTTON);
        }
    }
}