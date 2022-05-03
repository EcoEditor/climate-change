using System;
using Infrastructure.Services;
using RSG;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClimateChange.HandAttendingTest
{
    /// <summary>
    /// 0-2 nothing is happening
    ///2-3 start jump - jump animation speed 1/3 - 0.5 seconds - decide randomly up to 3.5 seconds
    ///3.5 - 5.5 - nothing is happening interval
    ///5.5- 7.5 - start animation - another animation is played
    ///8 - 12 - nothing is happening
    /// </summary>
    public class HandAttendingTestFlow : MonoBehaviour, IFlow
    {
        #region Editor

        [SerializeField] 
        private DigitsController _digitsController;
        
        [Tooltip("Setup minimum (x) and maximum (y) animation interval duration")]
        [SerializeField] 
        private Vector2 _animationIntervalDuration;

        [SerializeField] 
        private float _testDuration = 14f;

        #endregion
        
        #region Fields
        
        private bool _isTerminated;

        #endregion
        
        #region Methods

        public void Execute()
        {
            var startTime = Time.time;
            _digitsController.Setup();
            _isTerminated = false;
            
            CoroutineService.Instance.Delay(2f)
                .Then(() =>
                {
                    Debug.Log($"Entered animated first state {Time.time - startTime}");
                    return AnimatedState();
                })
                .Then(() => CoroutineService.Instance.Delay(3f))
                .Then(() =>
                {
                    Debug.Log($"First Digit Appear at {Time.time - startTime}");
                    return DigitAppearState();
                })
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() =>
                {
                    Debug.Log($"Entered second animated state {Time.time - startTime}");
                    return AnimatedState();
                })
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() =>
                {
                    Debug.Log($"Second Digit Appear {Time.time - startTime}");
                    return DigitAppearState();
                })
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() =>
                {
                    Debug.Log($"Entered third animated state {Time.time - startTime}");
                    return AnimatedState();
                })
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() =>
                {
                    Debug.Log($"Third digit appear {Time.time - startTime}");
                    return DigitAppearState();
                })
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() =>
                {
                    var currentTime = Time.time - startTime;
                    Debug.Log("Current time is: " + currentTime);
                    if (currentTime <= _testDuration - 2f)
                    {
                        Debug.Log($"Entered forth animated state {Time.time - startTime}");
                        AnimatedState();
                    }
                    var waitTime = _testDuration - currentTime;
                    Debug.Log($"Wait for another {waitTime}");
                    return CoroutineService.Instance.Delay(waitTime);
                })
                .Catch(ex =>
                {
                    Debug.Log("Promise chain was broken");
                })
                .Done(() =>
                {
                    Debug.Log($"Done Test Flow at time: {Time.time - startTime}");
                });
        }
        
        private IPromise AnimatedState()
        {
            var p = new Promise();
            var hands = FindObjectsOfType<AttendingHandController>();
            var randomHand = Random.Range(0, hands.Length);

            if (_isTerminated)
            {
                Debug.Log("Promise Animated State has been rejected due to termination");
                hands[randomHand].HaltAnimation();
                p.Reject(new Exception());
            }
            
            var animationDelay = Random.Range(_animationIntervalDuration.x, _animationIntervalDuration.y);
            hands[randomHand].PlayAnimationWithDelay(animationDelay, p);
            
            return p;
        }

        private IPromise DigitAppearState()
        {
            var p = new Promise();
            
            if (_isTerminated)
            {
                Debug.Log("Promise Show Digits has been rejected due to termination");
                p.Reject(new Exception());
            }
            
            _digitsController.RequestShowDigit(p);

            return p;
        }

        public void Terminate()
        {
            _isTerminated = true;
        }
        
        #endregion
    }

    public class Ques
    {
        public float FirstAnimationQue;
        public float FirstDigitQue;
        public float SecondAnimatedQue;
        public float SecondDigitQue;        
        public float ThirdAnimatedQue;
        public float ThirdDigitQue;
        public float ForthAnimationQue;
    }
}