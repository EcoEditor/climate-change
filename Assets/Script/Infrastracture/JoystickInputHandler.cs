using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClimateChange.Infrastracture
{
    public class JoystickInputHandler : MonoBehaviour
    {
        #region Events
        public event Action<InputAction.CallbackContext> OnMoveRight;
        public event Action<InputAction.CallbackContext> OnMoveLeft;
        public event Action<InputAction.CallbackContext> OnMoveUp;
        public event Action<InputAction.CallbackContext> OnMoveDown;
        public event Action<InputAction.CallbackContext> OnButtonPress;

        #endregion

        #region Fields
        private JoystickControlls _joystick;
        #endregion

        #region Methods

        protected void Awake()
        {
            _joystick = new JoystickControlls();
            _joystick.Gameplay.Enable();

            _joystick.Gameplay.Right.performed += MoveRight;
            _joystick.Gameplay.Left.performed += MoveLeft;
            _joystick.Gameplay.Up.performed += MoveUp;
            _joystick.Gameplay.Down.performed += MoveDown;
            _joystick.Gameplay.TriggerButton.performed += PressButton;
        }

        private void OnDestroy()
        { 
            _joystick.Gameplay.Right.performed -= MoveRight;
            _joystick.Gameplay.Left.performed -= MoveLeft;
            _joystick.Gameplay.Up.performed -= MoveUp;
            _joystick.Gameplay.Down.performed -= MoveDown;
            _joystick.Gameplay.TriggerButton.performed -= PressButton;

            _joystick.Gameplay.Disable();
        }

        private void MoveRight(InputAction.CallbackContext context)
        {
            OnMoveRight?.Invoke(context);
        }        
        
        private void MoveLeft(InputAction.CallbackContext context)
        {
            OnMoveLeft?.Invoke(context);
        }

        private void MoveUp(InputAction.CallbackContext context)
        {
            OnMoveUp?.Invoke(context);
        }

        private void MoveDown(InputAction.CallbackContext context)
        {
            Debug.Log("Moving Down");
            OnMoveDown?.Invoke(context);
        }        
        
        private void PressButton(InputAction.CallbackContext context)
        {
            Debug.Log("Trigger Button Pressed");
            OnButtonPress?.Invoke(context);
        }

        #endregion
    }
}