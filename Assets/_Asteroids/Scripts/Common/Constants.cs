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
    }
}