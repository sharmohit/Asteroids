using System;

namespace Asteroids.Events
{
    /// <summary>
    /// Hold All Game Actions.
    /// </summary>
    public static class GameEvents
    {
        // UI Action
        public static Action<string> UIButtonClicked;
        public static Action<UIScreen, bool> ShowUIScreen;

        // State Action
        public static Action<bool> GamePaused;

        public static Action GameCompleted;
        public static Action IncrementScore;
        public static Action ScoreUpdate;
    }
}