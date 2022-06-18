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

        [Header("Debug")]
        [SerializeField] 
        private bool DEBUG_MODE;
        
        [SerializeField] 
        private Hand _hand;        
        
        [Header("Hand tracking")]
        [SerializeField] 
        private OVRHand.Hand _ovrHand;

        [SerializeField] 
        private bool _didDetect;

        #endregion
        
        #region Methods
        
        protected void OnTriggerEnter(Collider other)
        {
            if (DEBUG_MODE)
            {
                var handController = other.gameObject.GetComponent<AttendingHandController>();
                if (handController == null) return;
                if (_hand != handController.Hand) return;
                Detect();
            }

            var ovrHand = other.GetComponentInParent<OVRHand>();
            if (ovrHand == null) return;
            if (ovrHand.MyHand == _ovrHand)
            {
                Detect();
            }
        }

        protected void OnTriggerExit(Collider other)
        {
            if (DEBUG_MODE)
            {
                if (other.gameObject.GetComponent<AttendingHandController>())
                {
                    DetectionLost();
                }
            }
            
            var ovrHand = other.GetComponentInParent<OVRHand>();
            if (ovrHand == null) return;
            if (ovrHand.MyHand == _ovrHand)
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