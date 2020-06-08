using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Controls player input commands.
    /// </summary>
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] float shootDelay = 0.25f;

        private PlayerShip playerShip;

        private ICommand moveFwdCmd;
        private ICommand rotateCmd;
        private ICommand shootCmd;
        private ICommand hyperspaceCmd;

        private float thrustInput;
        private float rotationInput;
        private float lastTime;

        private void Start()
        {
            playerShip = GetComponent<PlayerShip>();

            moveFwdCmd = new MoveForwardCommand();
            rotateCmd = new RotateCommand();
            shootCmd = new ShootCommand();
            hyperspaceCmd = new HyperspaceCommand();

            thrustInput = 0;
            rotationInput = 0;
            lastTime = 0;
        }

        void Update()
        {
            thrustInput = Input.GetAxis("Vertical");
            rotationInput = Input.GetAxis("Horizontal");

            if(thrustInput != 0)
            {
                moveFwdCmd.Execute(playerShip, thrustInput);
            }

            if (rotationInput != 0)
            {
                rotateCmd.Execute(playerShip, rotationInput);
            }

            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                hyperspaceCmd.Execute(playerShip);
            }

            if (Input.GetKey(KeyCode.Space) && Time.time > lastTime + shootDelay)
            {
                lastTime = Time.time;
                shootCmd.Execute(playerShip);
            }
        }
    }
}