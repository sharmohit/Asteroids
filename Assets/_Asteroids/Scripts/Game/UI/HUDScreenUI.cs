using UnityEngine;
using UnityEngine.UI;
using Asteroids.Events;

namespace Asteroids.UI
{
    /// <summary>
    /// Handle HUD Screen UI Elements.
    /// </summary>
    public class HUDScreenUI : MonoBehaviour
    {
        [SerializeField] Text scoreText;

        private void Start()
        {
            scoreText.text = "";
        }

        private void OnEnable()
        {
            GameEvents.ScoreUpdate += ScoreUpdate;
        }

        private void OnDisable()
        {
            GameEvents.ScoreUpdate -= ScoreUpdate;
        }

        private void ScoreUpdate(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}