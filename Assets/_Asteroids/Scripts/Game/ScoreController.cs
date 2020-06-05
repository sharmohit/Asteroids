using UnityEngine;
using Asteroids.Events;

namespace Asteroids.Controller
{
    /// <summary>
    /// Score Controller update and save score.
    /// </summary>
    public class ScoreController : MonoBehaviour
    {
        public int Score { get; private set; }

        private void OnEnable()
        {
            GameEvents.IncrementScore += AddScore;
        }

        private void Start()
        {
            Score = 0;
        }

        private void OnDisable()
        {
            GameEvents.IncrementScore -= AddScore;

            int lastScore = PlayerPrefs.GetInt(Constants.HIGH_SCORE_SAVE_KEY);

            if (lastScore < Score)
            {
                PlayerPrefs.SetInt(Constants.HIGH_SCORE_SAVE_KEY, Score);
            }
        }

        private void AddScore()
        {
            Score += 1;

            Debug.Log("Score " + Score);
            GameEvents.ScoreUpdate();
        }
    }
}