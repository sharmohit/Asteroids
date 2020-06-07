namespace Asteroids.Gameplay
{
    /// <summary>
    /// Interface for Player Input Command Execution.
    /// </summary>
    public interface ICommand
    {
        void Execute(PlayerShip playerShip, float inputValue = 0.0f);
    }
}