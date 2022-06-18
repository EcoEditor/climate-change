using ClimateChange.Infrastracture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClimateChange.View
{
    public class JoystickView : MonoBehaviour
    {

        public GameObject controller;

        public Rigidbody pivot;

        #region Fields

        private JoystickInputHandler _joystickInputHandler;
        private Transform _transform;

        #endregion

        #region Methods

        protected void Awake()
        {
            _transform = transform;
            _joystickInputHandler = FindObjectOfType<JoystickInputHandler>();

            _joystickInputHandler.OnMoveUp += OnMoveUp;
            _joystickInputHandler.OnMoveDown += OnMoveDown;
            _joystickInputHandler.OnMoveLeft += OnMoveLeft;
            _joystickInputHandler.OnMoveRight += OnMoveRight;
        }

        protected void OnDestroy()
        {
            _joystickInputHandler.OnMoveUp -= OnMoveUp;
            _joystickInputHandler.OnMoveDown -= OnMoveDown;
            _joystickInputHandler.OnMoveLeft -= OnMoveLeft;
            _joystickInputHandler.OnMoveRight -= OnMoveRight;
        }

        private void OnMoveUp(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (pivot.rotation.eulerAngles.y < 90)
                {
                    _transform.Rotate(0.10f, 0.0f, 0.0f, Space.Self);
                }
            } else
            {
                _transform.eulerAngles = new Vector3(
                _transform.eulerAngles.x * 0,
                _transform.eulerAngles.y * 0,
                _transform.eulerAngles.z * 0
                );
            }
        }   
        
        private void OnMoveDown(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Debug.Log("Joystick moving down");
                if (pivot.rotation.eulerAngles.z < 90)
                {
                    _transform.Rotate(-0.10f, 0.0f, 0.0f, Space.Self);
                }
            } else
            {
                _transform.eulerAngles = new Vector3(
                _transform.eulerAngles.x * 0,
                _transform.eulerAngles.y * 0,
                _transform.eulerAngles.z * 0
                );
            }
        }        
        
        private void OnMoveLeft(InputAction.CallbackContext context)
        {
            Debug.Log("Joystick moving right");

            if (context.phase == InputActionPhase.Performed)
            {
                if ((pivot.rotation.eulerAngles.z < 90) || (pivot.rotation.eulerAngles.z == 0))
                {
                    _transform.Rotate(0.0f, 0.0f, 0.10f, Space.Self);
                }
            } 
            else
            {
                _transform.eulerAngles = new Vector3(
                _transform.eulerAngles.x * 0,
                _transform.eulerAngles.y * 0,
                _transform.eulerAngles.z * 0
                );
            }
        }       
        
        private void OnMoveRight(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if ((pivot.rotation.eulerAngles.z > 270) || (pivot.rotation.eulerAngles.z == 0))
                {
                    this.transform.Rotate(0.0f, 0.0f, -0.10f, Space.Self);
                }
            } else
            {
                this.transform.eulerAngles = new Vector3(
                this.transform.eulerAngles.x * 0,
                this.transform.eulerAngles.y * 0,
                this.transform.eulerAngles.z * 0
                );
            }
        }

        #endregion
        
        protected void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (pivot.rotation.eulerAngles.y < 90)
                {
                    this.transform.Rotate(0.10f, 0.0f, 0.0f, Space.Self);
                }
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                this.transform.eulerAngles = new Vector3(
                    this.transform.eulerAngles.x * 0,
                    this.transform.eulerAngles.y * 0,
                    this.transform.eulerAngles.z * 0
                    );
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (pivot.rotation.eulerAngles.z < 90)
                {
                    this.transform.Rotate(-0.10f, 0.0f, 0.0f, Space.Self);
                }
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                this.transform.eulerAngles = new Vector3(
                   this.transform.eulerAngles.x * 0,
                   this.transform.eulerAngles.y * 0,
                   this.transform.eulerAngles.z * 0
                   );
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if ((pivot.rotation.eulerAngles.z > 270) || (pivot.rotation.eulerAngles.z == 0))
                {
                    this.transform.Rotate(0.0f, 0.0f, -0.10f, Space.Self);
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                this.transform.eulerAngles = new Vector3(
                   this.transform.eulerAngles.x * 0,
                   this.transform.eulerAngles.y * 0,
                   this.transform.eulerAngles.z * 0
                   );
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if ((pivot.rotation.eulerAngles.z < 90) || (pivot.rotation.eulerAngles.z == 0))
                {
                    this.transform.Rotate(0.0f, 0.0f, 0.10f, Space.Self);
                }
            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                this.transform.eulerAngles = new Vector3(
                   this.transform.eulerAngles.x * 0,
                   this.transform.eulerAngles.y * 0,
                   this.transform.eulerAngles.z * 0
                   );
            }
        }
    }
}