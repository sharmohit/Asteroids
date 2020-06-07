namespace Asteroids.Gameplay
{
    /// <summary>
    /// Process Hyperspace Command.
    /// </summary>
    public class HyperspaceCommand : ICommand
    {
        public void Execute(PlayerShip playerShip, float inputValue = 0)
        {
            playerShip.ActivateHyperspace();
        }
    }
}