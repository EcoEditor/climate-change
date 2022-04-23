using System.Collections;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class DetectorView : MonoBehaviour
    {
        #region Editor

        [SerializeField] 
        private GazeDetector _detector;
        
        [SerializeField] 
        private Renderer _renderer;
        
        [SerializeField] 
        private Color _detectedColor;
        
        [SerializeField] 
        private Color _undetectedColor;

        [SerializeField] 
        private float _speed;
        
        #endregion
        
        #region Methods

        protected void Awake()
        {
            _renderer.sharedMaterial.color = _undetectedColor;

            _detector.OnDetected += ShowDetected;
            _detector.OnDetectionLost += ShowUndetected;
        }

        protected void OnDestroy()
        {
            _detector.OnDetected -= ShowDetected;
            _detector.OnDetectionLost -= ShowUndetected;
        }

        private void ShowDetected()
        {
            StartCoroutine(SwitchColorDetectionStatus(_undetectedColor, _detectedColor, _speed));
        }

        private void ShowUndetected()
        {
            StartCoroutine(SwitchColorDetectionStatus(_detectedColor, _undetectedColor, _speed));
        }

        private IEnumerator SwitchColorDetectionStatus(Color from, Color to, float duration)
        {
            var startTime = Time.time;
            var elapsedTime = 0f;
            
            while (elapsedTime <= 1f)
            {
                elapsedTime = Time.time - startTime;
                var factor = elapsedTime / duration;
                _renderer.sharedMaterial.color = Color.Lerp(from, to, factor);
                yield return null;
            }
        }
        

        #endregion
    }
}