using UnityEngine;

namespace ClimateChange.HandAttendingTest.Models
{
    [CreateAssetMenu(fileName = "HandAttendingTestModel", menuName = "Hand Attending Test/Models/Hand Attending Test model")]
    public class HandAttendingTestModel : ScriptableObject
    {
        #region Editor

        [SerializeField] 
        private float _testDuration = 14f;

        #endregion
        
        #region Fields

        private Detectables _detactable;
        
        #endregion
        
        #region Methods

        public void Initialize(HandDetector rightHand, HandDetector leftHand, GazeDetector gazeDetector)
        {
            _detactable = new Detectables()
            {
                RightHand = rightHand,
                LeftHand = leftHand,
                Gaze = gazeDetector
            };
        }
        
        #endregion
        
        #region Properties

        public float TestDuration => _testDuration;
        public Detectables Detecatbles => _detactable;

        #endregion
    }
}