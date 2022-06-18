using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ClimateChange.HandAttendingTest
{
    public class ButtonController : MonoBehaviour
    {
        #region Events
        
        [SerializeField]
        private UnityEvent _OnClick;
        
        #endregion
        
        #region Editor
        
        [SerializeField] 
        private Transform _movingObject;
        
        [SerializeField] 
        private Transform _actionZone;

        [SerializeField] 
        private float _pressSpeed = 0.4f;
        
        [SerializeField]
        private float _releaseSpeed = 0.04f;
        
        [SerializeField]
        private bool _isInteractable;

        #endregion
        
        #region Fields

        private Vector3 _initialPosition;
        
        #endregion
        
        #region Methods

        protected void Awake()
        {
            _initialPosition = _movingObject.position;
            _isInteractable = true;
        }

        protected void OnTriggerStay(Collider other)
        {
            OnPressButton();
        }

        private void OnPressButton()
        {
            if (!_isInteractable) return;
            if (_movingObject.position.z <= _actionZone.position.z)
            {
                ButtonPressed();
                return;
            }
            
            _movingObject.Translate(Vector3.forward * _pressSpeed * Time.deltaTime, Space.Self);
        }

        private void ButtonPressed()
        {
            _isInteractable = false;
            _OnClick?.Invoke();
            OnReleaseButton();
        }

        private void OnReleaseButton()
        {
            StartCoroutine(ButtonReleased());
        }

        private IEnumerator ButtonReleased()
        {
            var t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * _releaseSpeed;
                _movingObject.position = Vector3.Lerp(_movingObject.position, _initialPosition, t);
                yield return null;
            }

            _isInteractable = true;
        }

        [ContextMenu("Test Press")]
        public void TestPress()
        {
            _isInteractable = false;
            _OnClick?.Invoke();
            OnReleaseButton();
        }
        
        #endregion
    }
}