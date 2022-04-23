using ClimateChange.HandAttendingTest.Models;

namespace ClimateChange.HandAttendingTest
{
    public class HandAttendingTestGenerator
    {
        #region Fields

        private DigitsModel _digitsModel;
        private HandAttendingTestModel _testModel;
        private IFlow _testFlow;

        #endregion
        
        #region Methods
        
        public HandAttendingTestGenerator(HandAttendingTestModel testModel, DigitsModel digitsModel)
        {
            _testModel = testModel;
            _digitsModel = digitsModel;
        }

        public void GenerateTest()
        {
            _testFlow.Execute();
        }

        public void TerminateTest()
        {
            
        }
        
        
        #endregion
    }
}