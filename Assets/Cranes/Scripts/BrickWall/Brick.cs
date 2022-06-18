using System;
using UnityEngine;

namespace ClimateChange.Gameplay
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private SphereCollider _ringCollider;
        [SerializeField] private HingeJoint _hingeJoint;

        //TODO make private after debugging:
        [SerializeField] private bool _didCollect;
        [SerializeField] private bool _inPlace;

        private Rigidbody _rigidbody;
        
        protected void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            DisableColliders();
        }

        public void DisableColliders()
        {
            _ringCollider.enabled = false;
        }

        public void EnableColliders()
        {
            _ringCollider.enabled = true;
        }

        public void Pickup(Rigidbody body)
        {
            _hingeJoint.connectedBody = body;
            _rigidbody.isKinematic = false;
            _didCollect = true;
        }

        public void Release()
        {
            _hingeJoint.connectedBody = null;
            _didCollect = false;
            _inPlace = true;
        }

        public bool DidCollect => _didCollect;
        public bool InPlace => _inPlace;
    }
}
