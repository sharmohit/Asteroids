using System;
using UnityEngine;

namespace Asteroids.Actions
{
    /// <summary>
    /// Holds all the game actions observers.
    /// </summary>
    public static class GameActions
    {
        // UI Action
        public static Action<string> UIButtonClicked;
        public static Action<UIScreen, bool> ShowUIScreen;

        // Game State Actions
        public static Action<bool> GamePaused;
        public static Action GameCompleted;

        // Gameplay Actions
        public static Action<int> AddScore;
        public static Action LevelUp;
        public static Action<int> LevelUpdate;
        public static Action<Action<int>> GetScore;
        public static Action<int> ScoreUpdate;
        public static Action<int> LivesUpdate;

        public static Action<GameObject> DestroyAsteroid;
        public static Action<GameObject> DestroyBigSaucer;
        public static Action<GameObject> DestroySmallSaucer;
        public static Action DestroyPlayer;

        public static Action PowerUpShield;
        public static Action PowerUpSlowMo;
    }
}