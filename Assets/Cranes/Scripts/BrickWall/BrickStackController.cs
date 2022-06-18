using System.Collections.Generic;
using UnityEngine;

namespace ClimateChange.Gameplay
{
    public class BrickStackController : MonoBehaviour
    {
        [SerializeField] private Brick[] _bricks;
        [SerializeField] private WallController _wallController;
 
        private Brick _currentBrick;
        private Stack<Brick> _bricksStack = new Stack<Brick>();

        protected void Awake()
        {
            GenerateBrickStack();
        }

        private void GenerateBrickStack()
        {
            for (int i = 0; i < _bricks.Length; i++)
            {
                _bricksStack.Push(_bricks[i]);
                _bricks[i].DisableColliders();
            }
        }

        [ContextMenu("Prepare next brick")]
        public void PrepareNextBrick()
        {
            var brick = _bricksStack.Pop();
            brick.EnableColliders();
            _wallController.ActivateNextCollider();
        }
    }
}
