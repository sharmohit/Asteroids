namespace Asteroids
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
            public const string PLAYER_BULLET_TAG = "PlayerBullet";
            public const string ENEMY_BULLET_TAG = "EnemyBullet";
            public const string PLAYER_TAG = "Player";
            public const string LARGE_ASTEROID = "LargeAsteroid";
            public const string BIG_SAUCER = "BigSaucer";
            public const string SMALL_SAUCER = "SmallSaucer";
            public const string SHIELD_POWER_UP = "ShieldPowerUp";
            public const string SLOW_MO_POWER_UP = "SlowMoPowerUp";
            public const string EXPLOSION_VFX = "VFX";
        }

        public struct Gameplay
        {
            public const int EXTRA_LIFE_MULTIPLE = 2;
            public const int LEVEL_UP_SCORE_MULTIPLE = 100;
            public const int SAUCER_SPAWN_LEVEL_MULTIPLE = 3;
            public const int SMALL_SAUCER_SOLO_LEVEL = 8;
            public const float BIG_SAUCER_SPAWN_TIME = 4.0f;
            public const float SMALL_SAUCER_SPAWN_TIME = 10.0f;

            public const float BULLET_LIFETIME = 1.2f;
            public const float NEXT_LEVEL_DELAY = 1.2f;
            public const float PLAYER_REVIVE_DELAY = 0.3f;
            public const float PLAYER_REVIVE_SHIELD_DURATION = 2f;
            public const float ASTEROID_SPAWN_MAX_HEIGHT = 0.8f;
            public const float ASTEROID_SPAWN_MIN_HEIGHT = 0.2f;
            public const float SAUCER_BIG_SPAWN_HEIGHT = 0.6f;
            public const float SAUCER_SMALL_SPAWN_HEIGHT = 0.75f;

            public const float POWER_UP_DURATION = 15.0f;
            public const int EXTRA_LIFE_POWER_UP_COUNT = 5;
        }

        public const string HIGH_SCORE_SAVE_KEY = "high_score";
    }
}