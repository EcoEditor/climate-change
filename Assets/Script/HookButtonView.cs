using UnityEngine;
using UnityEngine.UI;

namespace ClimateChange.View
{
    public class HookButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;

        protected void Awake()
        {
            _button.onClick.AddListener(LowerHookOnClick);
            CraneController.OnHookActivation += ActivateButton;
            CraneController.OnHookDeactivation += DeactivateButton;
        }

        protected void OnDestroy()
        {
            CraneController.OnHookActivation -= ActivateButton;
            CraneController.OnHookDeactivation -= DeactivateButton;
        }

        public void ActivateButton()
        {
            _button.interactable = true;
        }

        public void DeactivateButton()
        {
            _button.interactable = false;
        }

        private void LowerHookOnClick()
        {
            Debug.Log("Button is clicked");
        }
    }
}
