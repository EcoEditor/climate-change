using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class DigitsInputController : MonoBehaviour
    {
        #region Editor

        [SerializeField] private DigitsModel _digitModel;
        
        #endregion
        
        #region Fields

        private string _digits;
        
        #endregion
        public void AddDigit(string digit)
        {
            if (_digits.Length >= _digitModel.MaxDigitPerTest) return;
            _digits += digit;
        }

        public void DeleteDigit(string digit)
        {
            if (_digits.Length < 1) return;
            //_digits -= digit;
        }
    }
}