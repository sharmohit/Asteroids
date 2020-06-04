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
    }
}