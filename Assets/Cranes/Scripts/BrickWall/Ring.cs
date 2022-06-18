using System;
using UnityEngine;

namespace ClimateChange.Gameplay
{
    public class Ring : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;

        public void SetRingRadius(float radius)
        {
            _collider.radius = radius;
        }
    }
}