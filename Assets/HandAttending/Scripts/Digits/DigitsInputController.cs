using System;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class DigitsInputController : MonoBehaviour
    {
        #region Editor

        [SerializeField] 
        private DigitsModel _digitModel;

        [SerializeField] 
        private DigitInputScreenView _digitInputScreenView;
        
        #endregion
        
        #region Fields

        private string _digits = string.Empty;
        
        #endregion
        
        #region Methods
        
        public void AddDigit(string digit)
        {
            if (_digits.Length >= _digitModel.MaxDigitPerTest) return;
            _digits += digit;
            _digitInputScreenView.ShowDigit(_digits);
        }

        public void DeleteDigit()
        {
            if (_digits.Length < 1) return;
            _digits = _digits.Remove(_digits.Length - 1, 1);
            _digitInputScreenView.ShowDigit(_digits);
        }

        public void ConfirmDigits()
        {
            var isCorrect = CheckEnteredDigitSequence();

            if (isCorrect)
            {
                Debug.Log("Test is passed");
                _digitInputScreenView.ShowDigit("Correct");
                return;
            }
            
            _digitInputScreenView.ShowDigit("Please repeat the test");
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
        
        #endregion
    }
}