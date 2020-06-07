using System;
using UnityEngine;
using Asteroids.Actions;

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
            GameActions.AddScore += AddScore;
            GameActions.GetScore += GetScore;
        }

        private void Start()
        {
            Score = 0;
        }

        private void OnDisable()
        {
            GameActions.AddScore -= AddScore;

            int lastScore = PlayerPrefs.GetInt(Constants.HIGH_SCORE_SAVE_KEY);

            if (lastScore < Score)
            {
                PlayerPrefs.SetInt(Constants.HIGH_SCORE_SAVE_KEY, Score);
            }
        }

        private void AddScore(int value)
        {
            Score += value;

            GameActions.ScoreUpdate(Score);

            if(Score % 100 == 0)
            {
                GameActions.LevelUp();
            }
        }

        private void GetScore(Action<int> callback)
        {
            callback?.Invoke(Score);
        }
    }
}