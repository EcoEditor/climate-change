using System;
using UnityEngine;

namespace ClimateChange.Gameplay
{
    public class Hook : MonoBehaviour
    {
        [SerializeField] private SphereCollider _sphereCollider;
        [SerializeField] private string _ringTag = "Ring";
 
        private Rigidbody _rigidbody;

        protected void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(_ringTag)) return;
            var brick = other.GetComponentInParent<Brick>();
            if (brick == null) return;
            if (brick.DidCollect) return;
            AttachBrickToHook(brick);
        }

        private void AttachBrickToHook(Brick brick)
        {
            brick.Pickup(_rigidbody);
        }

        private void DetachBrickFromHook()
        {
            
        }
        
        public void SetColliderRadius(float radius)
        {
            _sphereCollider.radius = radius;
        }
    }
}
