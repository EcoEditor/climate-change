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

        public void ConfirmDigits()
        {
            var isCorrect = CheckEnteredDigitSequence();

            if (isCorrect)
            {
                Debug.Log("Test is passed");
                return;
            }
            
            Debug.Log("Test Failed!");
        }

        private bool CheckEnteredDigitSequence()
        {
            var digitSequence = _digitModel.Digits.Digit;
            var digitIntToString = string.Empty;

            for (int i = 0; i < digitSequence.Length; i++)
            {
                digitIntToString += digitSequence[i].ToString();
                Debug.Log(digitIntToString);
            }

            return string.Equals(digitIntToString, _digits);
        }
    }
}