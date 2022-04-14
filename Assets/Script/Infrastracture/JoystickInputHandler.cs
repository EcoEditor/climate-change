using UnityEngine;
using UnityEngine.InputSystem;

namespace ClimateChange.Infrastracture
{
    public class JoystickInputHandler : MonoBehaviour
    {
        private JoystickControlls _joystick;


        protected void Awake()
        {
            _joystick = new JoystickControlls();
            _joystick.Gameplay.Enable();

            _joystick.Gameplay.Right.performed += ctx => MoveRight();
            _joystick.Gameplay.Left.performed += MoveLeft;
            _joystick.Gameplay.Up.performed += MoveUp;
            _joystick.Gameplay.Down.performed += MoveDown;
            _joystick.Gameplay.TriggerButton.performed += ctx => MoveRight();
        }

        private void OnDestroy()
        {
            _joystick.Gameplay.Right.performed -= ctx => MoveRight();
            _joystick.Gameplay.Left.performed -= MoveLeft;
            _joystick.Gameplay.Up.performed -= MoveUp;
            _joystick.Gameplay.Down.performed -= MoveDown;
            _joystick.Gameplay.TriggerButton.performed -= ctx => MoveRight();

            _joystick.Gameplay.Disable();
        }

        private void MoveRight()
        {
            Debug.Log("Moving Right");
        }        
        
        private void MoveLeft(InputAction.CallbackContext context)
        {
            Debug.Log("Moving Left");
        }

        private void MoveUp(InputAction.CallbackContext context)
        {
            Debug.Log("Moving Up");

        }

        private void MoveDown(InputAction.CallbackContext context)
        {
            Debug.Log("Moving Down");

        }
    }
}
