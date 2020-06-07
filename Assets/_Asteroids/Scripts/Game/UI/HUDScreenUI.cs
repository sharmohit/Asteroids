using UnityEngine;
using UnityEngine.UI;
using Asteroids.Actions;

namespace Asteroids.UI
{
    /// <summary>
    /// Handle HUD Screen UI Elements.
    /// </summary>
    public class HUDScreenUI : MonoBehaviour
    {
        [SerializeField] Text scoreText;
        [SerializeField] Text levelText;

        private void Start()
        {
            scoreText.text = "0";
        }

        private void OnEnable()
        {
            GameActions.ScoreUpdate += ScoreUpdate;
            GameActions.LevelUpdate += LevelUpdate;
        }

        private void OnDisable()
        {
            GameActions.ScoreUpdate -= ScoreUpdate;
            GameActions.LevelUpdate -= LevelUpdate;
        }

        private void ScoreUpdate(int score)
        {
            scoreText.text = score.ToString();
        }

        private void LevelUpdate(int level)
        {
            levelText.text = level.ToString();
        }
    }
}