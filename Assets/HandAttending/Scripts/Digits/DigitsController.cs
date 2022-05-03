using RSG;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClimateChange.HandAttendingTest
{
    public class DigitsController : MonoBehaviour
    {
        #region Editor
        
        [SerializeField] 
        private DigitsModel _model;
        
        /// <summary>
        /// Digit requested to show 3 times, but to randomize the appearance it is shown 2 times.
        /// skipDigitCount has to be smaller than the number of show digits iterations in the HandAttendingTestFlow.cs
        /// </summary>
        [SerializeField]
        private int skipDigitsCount = 1;

        /// <summary>
        /// Number of requests to show digit, taken from HandAttendingTestFlow
        /// </summary>
        [SerializeField] 
        private int showDigitIterationsCount = 3;
        
        #endregion
        
        #region Fields

        private int _digitIndex;
        private int _skippedDigits;

        #endregion

        #region Methods

        // reset to default values after each test iteration
        public void Setup()
        {
            _digitIndex = 0;
            _skippedDigits = 0;
        }

        public void RequestShowDigit(Promise p)
        {
            var canSkip = CanSkipDigit();
            if (canSkip)
            {
                _skippedDigits++;
                p.Resolve();
                return;
            }
            
            _model.UpdateNextDigit(_digitIndex);
            _digitIndex++;
            p.Resolve();
        }

        private bool CanSkipDigit()
        {
            if (_skippedDigits >= skipDigitsCount) return false;

            // If chance to show was high on two occasions then third occasion is skipped
            if (showDigitIterationsCount - _digitIndex == 1)
            {
                return true;
            }
            
            var chanceToShow = Random.Range(0f, 1f);
            Debug.Log("Chance to show: " + chanceToShow);
            return chanceToShow < 0.5f;
        }
        
        #endregion
    }
}