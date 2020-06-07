﻿using System;
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

        // State Action
        public static Action<bool> GamePaused;

        public static Action GameCompleted;
        public static Action<int> AddScore;
        public static Action LevelUp;
        public static Action<Action<int>> GetScore;
        public static Action<int> ScoreUpdate;
        public static Action<int> LevelUpdate;

        public static Action<GameObject> DestroyAsteroid;
        public static Action DestroyBigSaucer;
        public static Action DestroyPlayer;
        public static Action PowerUpPickedUp;
    }
}