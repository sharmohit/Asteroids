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
        [SerializeField] Text livesText;

        private void Start()
        {
            scoreText.text = "0";
        }

        private void OnEnable()
        {
            GameActions.ScoreUpdate += ScoreUpdate;
            GameActions.LevelUpdate += LevelUpdate;
            GameActions.LivesUpdate += LivesUpdate;
        }

        private void OnDisable()
        {
            GameActions.ScoreUpdate -= ScoreUpdate;
            GameActions.LevelUpdate -= LevelUpdate;
            GameActions.LivesUpdate -= LivesUpdate;
        }

        private void ScoreUpdate(int score)
        {
            scoreText.text = score.ToString();
        }

        private void LevelUpdate(int level)
        {
            levelText.text = level.ToString();
        }

        private void LivesUpdate(int lives)
        {
            livesText.text = lives.ToString();
        }
    }
}