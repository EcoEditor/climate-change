using System;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class GazeDetector : MonoBehaviour, IDetector
    {
        #region Events

        public event Action OnDetected;
        public event Action OnDetectionLost;
        
        #endregion
        
        #region Editor

        [SerializeField] 
        private bool _didDetect;
        
        #endregion
        
        #region Methods

        public void GazeDetected()
        {
            if (_didDetect) return;
            _didDetect = true;
            OnDetected?.Invoke();
        }

        public void GazeDetectionLoss()
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