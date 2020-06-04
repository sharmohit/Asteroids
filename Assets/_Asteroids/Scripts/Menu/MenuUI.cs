using UnityEngine;
using UnityEngine.UI;
using Asteroids.Events;

namespace Asteroids.UI
{
    /// <summary>
    /// Update Menu UI Elements.
    /// </summary>
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] Button launchBtn;

        private void OnEnable()
        {
            launchBtn.onClick.AddListener(OnLaunchClicked);
        }

        private void OnDisable()
        {
            launchBtn.onClick.RemoveListener(OnLaunchClicked);
        }

        private void OnLaunchClicked()
        {
            GameEvents.UIButtonClicked(Constants.LAUNCH_BUTTON);
        }
    }
}