using System;
using ClimateChange.HandAttendingTest.Models;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClimateChange.HandAttendingTest
{
    [CreateAssetMenu(fileName = "DigitsModel", menuName = "Hand Attending Test/Models/Digits Model")]
    public class DigitsModel : ScriptableObject
    {
        #region Events

        public event Action<int> OnDigitChanged;
        public event Action<string> OnDigitEntered;
        
        #endregion
        
        #region Editor

        [SerializeField]
        private int _maxDigitPerTest = 2;        
        
        #endregion
        
        #region Fields

        private Digits _digits;
        
        #endregion
        
        #region Methods

        public void Initialize()
        {
            _digits = new Digits
            {
                Digit = new int[_maxDigitPerTest]
            };

            for (int i = 0; i < _maxDigitPerTest - 1; i++)
            {
                _digits.Digit[i] = GenerateRandomDigit();
            }
        }
        
        private int GenerateRandomDigit()
        {
            var random = Random.Range(0, 10);
            return random;
        }

        public void UpdateNextDigit(int index)
        {
            OnDigitChanged?.Invoke(_digits.Digit[index]);
        }

        #endregion
        
        #region Properties

        public Digits Digits => _digits;
        public int MaxDigitPerTest => _maxDigitPerTest;

        #endregion
    }
}