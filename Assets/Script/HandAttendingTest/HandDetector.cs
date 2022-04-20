using System;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class HandDetector : MonoBehaviour
    {
        #region Events

        public event Action<Hand> OnHandDetected;
        public event Action<Hand> OnHandDetectedLost;
        
        #endregion
        
        #region Editor

        #endregion
        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<AttendingHand>())
            {
                
            }
        }
    }
}