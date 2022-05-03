using System;

namespace ClimateChange.HandAttendingTest
{
    public class DetectionController : IDisposable
    {
        public event Action<bool> OnDetectionChanged;
        
        private Detectables _detectables;

        public DetectionController(Detectables detectables)
        {
            _detectables = detectables;
            
            _detectables.RightHand.OnDetected += UpdateDetectionStatus;
            _detectables.RightHand.OnDetectionLost += UpdateDetectionStatus;

            _detectables.LeftHand.OnDetected += UpdateDetectionStatus;
            _detectables.LeftHand.OnDetectionLost += UpdateDetectionStatus;
            
            _detectables.Gaze.OnDetected += UpdateDetectionStatus;
            _detectables.Gaze.OnDetectionLost += UpdateDetectionStatus;
        }

        public void Dispose()
        {
            _detectables.RightHand.OnDetected -= UpdateDetectionStatus;
            _detectables.RightHand.OnDetectionLost -= UpdateDetectionStatus;

            _detectables.LeftHand.OnDetected -= UpdateDetectionStatus;
            _detectables.LeftHand.OnDetectionLost -= UpdateDetectionStatus;
            
            _detectables.Gaze.OnDetected -= UpdateDetectionStatus;
            _detectables.Gaze.OnDetectionLost -= UpdateDetectionStatus;
        }
        
        private void UpdateDetectionStatus()
        {
            var allDetected = _detectables.RightHand.DidDetect
                              & _detectables.LeftHand.DidDetect
                              & _detectables.Gaze.DidDetect;

            OnDetectionChanged?.Invoke(allDetected);
        }
    }

    public struct Detectables
    {
        public IDetector RightHand;
        public IDetector LeftHand;
        public IDetector Gaze;
    }
}