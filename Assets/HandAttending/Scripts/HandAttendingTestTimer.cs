using ClimateChange.HandAttendingTest.Models;
using RSG;

namespace ClimateChange.HandAttendingTest
{
    public class HandAttendingTestTimer
    {
        #region Fields
        
        private HandAttendingTestModel _model;
        private PromiseTimer _timer;
        private float _startTime;

        #endregion
        
        #region Constuctor

        public HandAttendingTestTimer(HandAttendingTestModel model)
        {
            _model = model;
        }
        
        #endregion
        
        #region Methods

        public void StartTimer()
        {
            
        }

        public void StopTimer()
        {
            
        }
        
        #endregion
    }
}