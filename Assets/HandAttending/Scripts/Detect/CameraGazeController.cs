using System;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class CameraGazeController : MonoBehaviour
    {
        #region Editor
        
        [SerializeField] 
        private LayerMask _gazeDetectorLayer;
        
        #endregion
        
        #region Fields

        private Transform _transform;
        private GazeDetector _detector;
        
        #endregion
        
        #region Methods

        protected void Awake()
        {
            _transform = transform;
        }

        protected void Update()
        {
            Detect();
        }

        private void Detect()
        {
            var didHit = Physics.Raycast(_transform.position, _transform.TransformDirection(Vector3.forward),
                out var hit, float.MaxValue, _gazeDetectorLayer);
            
            Debug.DrawLine(_transform.position, _transform.TransformDirection(Vector3.forward * 10f), Color.green, 5f);

            if (!didHit)
            {
                if (_detector == null) return;
                _detector.GazeDetectionLoss();
                _detector = null;
                return;
            }

            _detector = hit.collider.gameObject.GetComponent<GazeDetector>();
            if (_detector == null) return;
            _detector.GazeDetected();
        }

        #endregion
    }
}