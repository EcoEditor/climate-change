using System;
using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class AttendingHand : MonoBehaviour
    {
        #region Editor
        
        [SerializeField] 
        private Hand _hand;

        [SerializeField] 
        private Animator _animator;

        [SerializeField] 
        private string _handMoveAnimationName;

        #endregion
        
        #region Fields

        private int _handMoveAnimationHash;

        #endregion

        #region Methods

        protected void Awake()
        {
            _handMoveAnimationHash = Animator.StringToHash(_handMoveAnimationName);
        }

        #endregion

    }
}
