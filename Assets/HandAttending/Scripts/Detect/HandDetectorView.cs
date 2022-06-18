using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ClimateChange.HandAttendingTest
{
    public class HandDetectorView : MonoBehaviour
    {
        #region Editor

        [SerializeField] 
        private HandDetector _detector;
        
        [SerializeField]
        private Image _fillImage;

        [SerializeField] 
        private float _fillDuration;
        
        #endregion
        
        #region Methods

        protected void Awake()
        {
            _fillImage.fillAmount = 0f;

            _detector.OnDetected += FillImageInternal;
            _detector.OnDetectionLost += ResetImage;
        }

        protected void OnDestroy()
        {
            _detector.OnDetected -= FillImageInternal;
            _detector.OnDetectionLost -= ResetImage;
        }

        private void FillImageInternal()
        {
            StartCoroutine(FillImageRoutine());
        }

        private void ResetImage()
        {
           StopCoroutine(FillImageRoutine());
           _fillImage.fillAmount = 0f;
        }
        
        private IEnumerator FillImageRoutine()
        {
            Debug.Log("Starting coroutine");
            var startTime = Time.time;
            var elapsedTime = 0f;
            
            while (elapsedTime <= 1f)
            {
                elapsedTime = Time.time - startTime;
                var factor = elapsedTime / _fillDuration;
                _fillImage.fillAmount = factor;
                yield return null;
            }
        }

        #endregion
    }
}

