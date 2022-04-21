using System;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class HandDetector : MonoBehaviour, IDetector
    {
        #region Events

        public event Action OnDetected;
        public event Action OnDetectionLost;
        
        #endregion
        
        #region Editor

        [SerializeField] 
        private Hand _hand;

        [SerializeField] 
        private bool _didDetect;

        #endregion
        
        #region Methods
        
        protected void OnTriggerEnter(Collider other)
        {
            var handController = other.gameObject.GetComponent<AttendingHandController>();
            if (handController == null) return;
            if (_hand != handController.Hand) return;
            Detect();
        }

        protected void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<AttendingHandController>())
            {
                DetectionLost();
            }
        }

        private void Detect()
        {
            if (_didDetect) return;
            _didDetect = true;
            OnDetected?.Invoke();
        }

        private void DetectionLost()
        {
            _didDetect = false;
            OnDetectionLost?.Invoke();
        }
        
        #endregion
        
        #region Properties

        public bool DidDetect => _didDetect;

        #endregion
    }
}