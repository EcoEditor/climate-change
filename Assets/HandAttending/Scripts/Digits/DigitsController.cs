using RSG;

namespace ClimateChange.HandAttendingTest
{
    public class DigitsController
    {
        #region Consts

        private const float START_DELAY = 5f;
        
        #endregion
        
        #region Fields

        private DigitsModel _model;
        private IPromiseTimer _timer;

        #endregion

        #region Methods

        public DigitsController(DigitsModel model)
        {
            _model = model;
            _model.Initialize();
            
            _timer = new PromiseTimer();
            StartTimer();
        }

        private void StartTimer()
        {
            _timer.WaitFor(START_DELAY);
        }
        
        #endregion
    }
}