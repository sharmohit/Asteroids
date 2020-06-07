using UnityEngine;
using UnityEngine.UI;
using Asteroids.Actions;

namespace Asteroids.UI
{
    /// <summary>
    /// Handle Menu Screen UI Elements.
    /// </summary>
    public class MenuScreenUI : MonoBehaviour
    {
        [SerializeField] Button launchBtn;
        [SerializeField] Text highScore;

        private void OnEnable()
        {
            launchBtn.onClick.AddListener(LaunchClicked);
        }

        private void Start()
        {
            highScore.text = PlayerPrefs.GetInt(Constants.HIGH_SCORE_SAVE_KEY).ToString();
        }

        private void OnDisable()
        {
            launchBtn.onClick.RemoveListener(LaunchClicked);
        }

        private void LaunchClicked()
        {
            GameActions.UIButtonClicked(Constants.Buttons.LAUNCH_BUTTON);
        }
    }
}