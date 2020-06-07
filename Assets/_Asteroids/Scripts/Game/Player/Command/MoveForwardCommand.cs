namespace Asteroids.Gameplay
{
    /// <summary>
    /// Process Move Forward Command.
    /// </summary>
    public class MoveForwardCommand : ICommand
    {
        public void Execute(PlayerShip playerShip, float inputValue = 0)
        {
            playerShip.MoveForward(inputValue);
        }
    }
}