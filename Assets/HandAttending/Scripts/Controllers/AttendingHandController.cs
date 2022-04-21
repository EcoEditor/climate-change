using UnityEngine;

namespace ClimateChange.HandAttendingTest
{
    public class AttendingHandController : MonoBehaviour
    {
        #region Editor
        
        [SerializeField] 
        private Hand _hand;

        [SerializeField] 
        private Animator _animator;

        [SerializeField] 
        private AnimationName _handMoveAnimationName;

        #endregion
        
        #region Fields

        private int _handMoveAnimationHash;

        #endregion

        #region Methods

        protected void Awake()
        {
            _handMoveAnimationHash = Animator.StringToHash(_handMoveAnimationName.ToString());
        }

        public void PlayAnimation(Hand hand, float speed)
        {
            if (hand != _hand) return;
            _animator.speed = speed;
            _animator.SetTrigger(_handMoveAnimationHash);
        }

        #endregion
        
        #region Properties

        public Hand Hand => _hand;

        #endregion
    }
}