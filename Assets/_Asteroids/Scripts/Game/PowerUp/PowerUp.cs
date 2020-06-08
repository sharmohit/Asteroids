using Asteroids.Actions;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Power up is based on space object.
    /// </summary>
    public class PowerUp : SpaceObject
    {
        public override void OnEnable()
        {
            base.OnEnable();

            GameActions.GameCompleted += GameCompleted;
        }

        public override void OnDisable()
        {
            base.OnDisable();

            GameActions.GameCompleted -= GameCompleted;
        }

        private void GameCompleted()
        {
            gameObject.SetActive(false);
        }
    }
}