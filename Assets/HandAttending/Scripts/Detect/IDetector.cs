using System;

namespace ClimateChange.HandAttendingTest
{
    public interface IDetector
    {
        event Action OnDetected;
        event Action OnDetectionLost;
        bool DidDetect { get; }
    }
}