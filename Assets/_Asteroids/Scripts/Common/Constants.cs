﻿namespace Asteroids
{
    /// <summary>
    /// Game States Enum.
    /// </summary>
    public enum GameState
    {
        None,
        Menu,
        Running,
        Pause,
        Result,
    }

    public enum UIScreen
    {
        Pause,
        HUD,
        Result
    }

    /// <summary>
    /// Holds Game Constants.
    /// </summary>
    public static class Constants
    {
        public struct Buttons
        {
            public const string LAUNCH_BUTTON = "Launch";
            public const string RETRY_BUTTON = "Retry";
            public const string QUIT_BUTTON = "Quit";
        }

        public struct Scenes
        {
            public const string MENU_SCENE = "Menu";
            public const string GAME_SCENE = "Game";
        }

        public struct Tags
        {
            public const string PLAYER_BULLET_TAG = "Bullet";
            public const string PLAYER_TAG = "Player";
        }

        public struct Gameplay
        {
            public const int LEVEL_UP_SCORE_MULTIPLE = 100;
            public const float NEXT_LEVEL_DELAY = 1.2f;
            public const float PLAYER_REVIVE_DELAY = 0.5f;
        }

        public const string HIGH_SCORE_SAVE_KEY = "high_score";
    }
}