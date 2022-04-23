using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClimateChange.HandAttendingTest
{
    public class DigitsView : MonoBehaviour
    {
        #region Editor
        
        [SerializeField] 
        private DigitsModel _model;
        
        [SerializeField] 
        private TMP_Text _digitText;

        [SerializeField] 
        private RectTransform[] _textRectTransforms;

        #endregion
        
        #region Fields

        private bool _isRightHand;
        
        #endregion
        
        #region Methods
        
        protected void Awake()
        {
            _model.OnDigitChanged += ShowDigit;
        }

        protected void OnDestroy()
        {
            _model.OnDigitChanged -= ShowDigit;
        }

        private void ShowDigit(int digit)
        {
            //1. Set position - right/left hand
            var randomIndex = Random.Range(0, _textRectTransforms.Length);
            _digitText.rectTransform.position = _textRectTransforms[randomIndex].position;
            
            //2. Show text
            _digitText.text = digit.ToString();

            StartCoroutine(HideWithDelay());
        }

        private IEnumerator HideWithDelay()
        {
            yield return new WaitForSeconds(0.5f);
            _digitText.text = String.Empty;
        }
        
        #endregion
    }
}