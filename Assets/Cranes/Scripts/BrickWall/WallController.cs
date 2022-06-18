using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClimateChange.Gameplay
{
    public class WallController : MonoBehaviour
    {
        [SerializeField] private BoxCollider[] _bricksCollider;

        [SerializeField] private float _colliderSizeFactor = 0.9f;

        private Stack<BoxCollider> _collidersStack = new Stack<BoxCollider>();

        protected void Awake()
        {
            for (int i = 0; i < _bricksCollider.Length; i++)
            {
                _collidersStack.Push(_bricksCollider[i]);
            }
            DeactivateColliders();
        }

        public void ActivateNextCollider()
        {
            var placedBrick = _collidersStack.Pop();
            placedBrick.enabled = true;
            placedBrick.size *= _colliderSizeFactor;
        }

        private void DeactivateColliders()
        {
            for (int i = 0; i < _bricksCollider.Length; i++)
            {
                _bricksCollider[i].enabled = false;
            }
        }
    }
}
