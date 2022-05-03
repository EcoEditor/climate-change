using System.Collections;
using Magnifica.LenaTest.View;
using UnityEngine;

namespace Magnifica.LenaTest.Controllers
{
    public class ButtonController : MonoBehaviour
    {
        #region Editor

        [SerializeField] 
        private GameController _controller;

        [SerializeField] 
        private ButtonView _buttonView;
        
        [SerializeField] 
        private Transform _movingObject;
        
        [SerializeField] 
        private Transform _contactZone;

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
            if (_movingObject.position.y <= _contactZone.position.y)
            {
                ButtonPressed();
                return;
            }
            
            _movingObject.Translate(Vector3.down * _pressSpeed * Time.deltaTime, Space.Self);
        }

        private void ButtonPressed()
        {
            _controller.StartRound();
            _buttonView.Deactivate();
            _isInteractable = false;
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

            _buttonView.Activate();
            _isInteractable = true;
        }
        
        #endregion
    }
}