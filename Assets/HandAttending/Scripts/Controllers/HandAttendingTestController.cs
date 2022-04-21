using ClimateChange.HandAttendingTest.Models;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class HandAttendingTestController : MonoBehaviour
    {
        #region Editor

        [SerializeField] 
        private HandAttendingTestModel _model;

        [SerializeField] 
        private HandDetector _rightHandDetector;
        
        [SerializeField] 
        private HandDetector _leftHandDetector;
        
        [SerializeField] 
        private GazeDetector _gazeDetector;
        
        #endregion
        
        #region Fields

        private HandAttendingTestGenerator _generator;
        private DetectionController _detectionController;
        
        #endregion
        
        #region Methods

        protected void Awake()
        {
            _generator = new HandAttendingTestGenerator(_model);
            _model.Initialize(_rightHandDetector, _leftHandDetector, _gazeDetector);
            _detectionController = new DetectionController(_model.Detecatbles);
            _detectionController.OnAllDetected += RequestStartTest;
        }

        private void RequestStartTest(bool isReady)
        {
            if (!isReady) return;
            StartTest();
        }
        
        private void StartTest()
        {
            
        }

        private void RestartTest()
        {
            
        }

        private void TestCompleted()
        {
            
        }

        #endregion
    }
}