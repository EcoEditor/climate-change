using ClimateChange.HandAttendingTest.Models;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class HandAttendingTestController : MonoBehaviour
    {
        #region Editor

        [SerializeField] 
        private HandAttendingTestModel _testModel;

        [SerializeField] 
        private DigitsModel _digitsModel;

        [SerializeField] 
        private HandDetector _rightHandDetector;
        
        [SerializeField] 
        private HandDetector _leftHandDetector;
        
        [SerializeField] 
        private GazeDetector _gazeDetector;

        [SerializeField] 
        private HandAttendingTestFlow _testFlow;
        
        #endregion
        
        #region Fields

        private HandAttendingTestGenerator _generator;
        private DetectionController _detectionController;
        
        #endregion
        
        #region Methods

        protected void Awake()
        {
            _generator = new HandAttendingTestGenerator(_testModel, _digitsModel);
            _testModel.Initialize(_rightHandDetector, _leftHandDetector, _gazeDetector);
            _digitsModel.Initialize();
            _detectionController = new DetectionController(_testModel.Detecatbles);
            _detectionController.OnDetectionChanged += RequestStartTest;
        }

        private void RequestStartTest(bool isReady)
        {
            if (!isReady)
            {
                TerminateTest();
                return;
            }
            StartTest();
        }
        
        private void StartTest()
        { 
            _testFlow.Execute();
        }

        private void TerminateTest()
        {
            _testFlow.Terminate();
        }

        private void TestCompleted()
        {
            
        }

        #endregion
    }
}