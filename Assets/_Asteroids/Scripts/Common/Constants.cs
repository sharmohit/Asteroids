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

    /// <summary>
    /// Holds Game Constants.
    /// </summary>
    public class Constants
    {
        // UI Buttons
        public const string LAUNCH_BUTTON = "Launch";

        // Scenes
        public const string MENU_SCENE = "Menu";
        public const string GAME_SCENE = "Game";
    }
}