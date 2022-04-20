using System;
using System.Collections;
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
            StartCoroutine(MoveRightRoutine(context));
        }

        private IEnumerator MoveRightRoutine(InputAction.CallbackContext context)
        {
            while(context.phase == InputActionPhase.Performed)
            {
                yield return null;
                Debug.Log("Moving right with routine");
                OnMoveRight?.Invoke(context);
            }
        }
        
        private void MoveLeft(InputAction.CallbackContext context)
        {
            Debug.Log("Moving Left");
            StartCoroutine(MoveLeftRoutine(context));
        }

        private IEnumerator MoveLeftRoutine(InputAction.CallbackContext context)
        {
            while (context.phase == InputActionPhase.Performed)
            {
                yield return null;
                Debug.Log("Moving left with routine");
                OnMoveLeft?.Invoke(context);
            }
        }

        private void MoveUp(InputAction.CallbackContext context)
        {
            Debug.Log("Moving Up");
            StartCoroutine(MoveUpRoutine(context));
        }

        private IEnumerator MoveUpRoutine(InputAction.CallbackContext context)
        {
            while (context.phase == InputActionPhase.Performed)
            {
                yield return null;
                Debug.Log("Moving Up with routine");
                OnMoveUp?.Invoke(context);
            }
        }

        private void MoveDown(InputAction.CallbackContext context)
        {
            Debug.Log("Moving Down");
            StartCoroutine(MoveDownRoutine(context));
        }

        private IEnumerator MoveDownRoutine(InputAction.CallbackContext context)
        {
            while (context.phase == InputActionPhase.Performed)
            {
                yield return null;
                Debug.Log("Moving down with routine");
                OnMoveDown?.Invoke(context);
            }
        }

        private void PressButton(InputAction.CallbackContext context)
        {
            Debug.Log("Trigger Button Pressed");
            StartCoroutine(PressButtonRoutine(context));
        }

        private IEnumerator PressButtonRoutine(InputAction.CallbackContext context)
        {
            while (context.phase == InputActionPhase.Performed)
            {
                yield return null;
                Debug.Log("Button is pressed");
                OnButtonPress?.Invoke(context);
            }
        }

        #endregion
    }
}