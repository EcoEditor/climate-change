using System;
using UnityEngine;

namespace ClimateChange.Gameplay
{
    public class PlacedBrick : MonoBehaviour
    {
        [SerializeField] private GameObject _placedBrick;
        [SerializeField] private Transform _pivotPoint;

        private Collider _brickCollider;
        
        protected void OnTriggerEnter(Collider other)
        {
            var brick = other.GetComponentInParent<Brick>();
            if (brick == null) return;
            PlaceBrick(brick);
        }

        private void PlaceBrick(Brick brick)
        {
            brick.Release();
            brick.gameObject.SetActive(false);
            _placedBrick.gameObject.SetActive(true);
        }

        public Collider BrickCollider => _brickCollider;
    }
}