using System.Collections;
using UnityEngine;

namespace Magnifica.LenaTest.View
{
    public class ButtonView : MonoBehaviour
    {
        #region Editor
        
        [SerializeField] 
        private Renderer _renderer;
        
        [SerializeField] 
        private Color _activatedColor;
        
        [SerializeField] 
        private Color _deactivatedColor;

        [SerializeField] 
        private float _changeColorSpeed = 0.05f;

        #endregion

        #region Methods

        protected void Awake()
        {
            _renderer.sharedMaterial.color = _activatedColor;
        }

        public void Activate()
        {
            StartCoroutine(ActivateInternal());
        }

        private IEnumerator ActivateInternal()
        {
            var t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * _changeColorSpeed;
                _renderer.sharedMaterial.color = Color.Lerp(_deactivatedColor, _activatedColor, t);
                yield return null;
            }
        }
        
        public void Deactivate()
        {
            _renderer.sharedMaterial.color = _deactivatedColor;
        }

        #endregion

    }
}