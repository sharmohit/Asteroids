namespace Asteroids.Gameplay
{
    /// <summary>
    /// Process Rotate Command.
    /// </summary>
    public class RotateCommand : ICommand
    {
        public void Execute(PlayerShip playerShip, float inputValue = 0)
        {
            playerShip.RotateShip(inputValue);
        }
    }
}