namespace Asteroids.Gameplay
{
    /// <summary>
    /// Process Shoot Command.
    /// </summary>
    public class ShootCommand : ICommand
    {
        public void Execute(PlayerShip playerShip, float inputValue = 0)
        {
            playerShip.Shoot();
        }
    }
}