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
        private int score;
        private int level;

        private void OnEnable()
        {
            GameActions.AddScore += AddScore;
            GameActions.GetScore += GetScore;
        }

        private void Start()
        {
            score = 0;
            level = 1;
            GameActions.LevelUpdate(level);
        }

        private void OnDisable()
        {
            GameActions.AddScore -= AddScore;
            GameActions.GetScore -= GetScore;

            int lastScore = PlayerPrefs.GetInt(Constants.HIGH_SCORE_SAVE_KEY);

            if (lastScore < score)
            {
                PlayerPrefs.SetInt(Constants.HIGH_SCORE_SAVE_KEY, score);
            }
        }

        private void AddScore(int value)
        {
            score += value;

            GameActions.ScoreUpdate?.Invoke(score);

            if (Mathf.Floor(score / Constants.Gameplay.LEVEL_UP_SCORE_MULTIPLE) > level)
            {
                level++;
                GameActions.LevelUpdate(level);
            }
        }

        private void GetScore(Action<int> callback)
        {
            callback?.Invoke(score);
        }
    }
}