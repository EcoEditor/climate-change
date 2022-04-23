using System.Collections;
using RSG;
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

        [Tooltip("Setup minimum (x) and maximum (y) animation speed")]
        [SerializeField]
        private Vector2 _animationSpeedRange;

        #endregion
        
        #region Fields

        private int _handMoveAnimationHash;

        #endregion

        #region Methods

        protected void Awake()
        {
            _handMoveAnimationHash = Animator.StringToHash(_handMoveAnimationName.ToString());
        }

        public IPromise PlayAnimationWithDelay(float delay, IPendingPromise p)
        {
            var promise = new Promise();
            StartCoroutine(PlayAnimationInternal(delay, p));
            return promise;
        }

        private IEnumerator PlayAnimationInternal(float delay, IPendingPromise p)
        {
            yield return new WaitForSeconds(delay);
            var animationSpeed = Random.Range(_animationSpeedRange.x, _animationSpeedRange.y);
            _animator.speed = animationSpeed;
            _animator.SetTrigger(_handMoveAnimationHash);
            
            p.Resolve();
        }

        public void HaltAnimation()
        {
            StopAllCoroutines();
        }

        #endregion
        
        #region Properties

        public Hand Hand => _hand;

        #endregion
    }
}