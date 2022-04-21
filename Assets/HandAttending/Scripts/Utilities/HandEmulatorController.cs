using System.Collections;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class HandEmulatorController : MonoBehaviour
    {
        #region Editor
        
        [SerializeField] 
        private Transform _hands;
        
        [SerializeField] 
        private Vector3 _initialPosition;
        
        [SerializeField] 
        private Vector3 _contactPosition;

        [SerializeField] 
        private float emulatorSpeed = 1f;
        
        #endregion
        
        #region Methods

        protected void Awake()
        {
            _hands.position = _initialPosition;
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                LowerHands();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                RaiseHands();
            }
        }

        private void LowerHands()
        {
            StartCoroutine(HandsMovementRoutine(_hands.position, _contactPosition, emulatorSpeed));
        }

        private void RaiseHands()
        {
            StartCoroutine(HandsMovementRoutine(_hands.position, _initialPosition, emulatorSpeed));
        }

        private IEnumerator HandsMovementRoutine(Vector3 from, Vector3 to, float duration)
        {
            var startTime = Time.time;
            var elapsedTime = 0f;
            
            while (elapsedTime <= 1f)
            {
                elapsedTime = Time.time - startTime;
                var factor = elapsedTime / duration;
                _hands.position = Vector3.Lerp(from, to, factor);
                yield return null;
            }
        }

        #endregion
    }
}