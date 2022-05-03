using TMPro;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class DigitInputScreenView : MonoBehaviour
    {
        #region Editor

        [SerializeField] private TMP_Text _digitText;

        #endregion
        
        #region Methods

        public void ShowDigit(string digit)
        {
            _digitText.text = digit;
        }
        
        #endregion
    }
}