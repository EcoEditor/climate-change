//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Script/Infrastracture/JoystickControlls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @JoystickControlls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @JoystickControlls()
    {
        asset = InputActionAsset.FromJson(@"{
""name"": ""JoystickControlls"",
""maps"": [
    {
        ""name"": ""Gameplay"",
        ""id"": ""0198821f-5468-4870-8dc2-f622bfe566c9"",
        ""actions"": [
            {
                ""name"": ""Right"",
                ""type"": ""Button"",
                ""id"": ""56bc7af3-fb17-4321-9604-987350137c93"",
                ""expectedControlType"": ""Button"",
                ""processors"": """",
                ""interactions"": """",
                ""initialStateCheck"": false
            },
            {
                ""name"": ""Left"",
                ""type"": ""Button"",
                ""id"": ""e6f206ce-a9ea-436a-8177-626019d98af7"",
                ""expectedControlType"": ""Button"",
                ""processors"": """",
                ""interactions"": """",
                ""initialStateCheck"": false
            },
            {
                ""name"": ""Up"",
                ""type"": ""Button"",
                ""id"": ""c655af7b-bbc2-4441-bfd5-dd31a6319248"",
                ""expectedControlType"": ""Button"",
                ""processors"": """",
                ""interactions"": """",
                ""initialStateCheck"": false
            },
            {
                ""name"": ""Down"",
                ""type"": ""Button"",
                ""id"": ""d81f980e-ac45-4bad-961f-77198593545e"",
                ""expectedControlType"": ""Button"",
                ""processors"": """",
                ""interactions"": """",
                ""initialStateCheck"": false
            },
            {
                ""name"": ""TriggerButton"",
                ""type"": ""Button"",
                ""id"": ""e7dc8590-f0d8-4d40-a558-d0d941847117"",
                ""expectedControlType"": ""Button"",
                ""processors"": """",
                ""interactions"": """",
                ""initialStateCheck"": false
            }
        ],
        ""bindings"": [
            {
                ""name"": """",
                ""id"": ""be5fe6aa-b9ad-49ab-8f4f-c090a59ead34"",
                ""path"": ""<HID::ACRUX SL-6632 Dark Tornado Joystick>/stick/right"",
                ""interactions"": """",
                ""processors"": """",
                ""groups"": """",
                ""action"": ""Right"",
                ""isComposite"": false,
                ""isPartOfComposite"": false
            },
            {
                ""name"": """",
                ""id"": ""dcca20f5-abd3-4860-8f66-a96b8c45b948"",
                ""path"": ""<HID::ACRUX SL-6632 Dark Tornado Joystick>/stick/left"",
                ""interactions"": """",
                ""processors"": """",
                ""groups"": """",
                ""action"": ""Left"",
                ""isComposite"": false,
                ""isPartOfComposite"": false
            },
            {
                ""name"": """",
                ""id"": ""6bef7f9f-aaba-415d-b012-9a18a067b746"",
                ""path"": ""<HID::ACRUX SL-6632 Dark Tornado Joystick>/stick/up"",
                ""interactions"": """",
                ""processors"": """",
                ""groups"": """",
                ""action"": ""Up"",
                ""isComposite"": false,
                ""isPartOfComposite"": false
            },
            {
                ""name"": """",
                ""id"": ""d0253620-80bf-4910-9d2c-734394af5f81"",
                ""path"": ""<HID::ACRUX SL-6632 Dark Tornado Joystick>/stick/down"",
                ""interactions"": """",
                ""processors"": """",
                ""groups"": """",
                ""action"": ""Down"",
                ""isComposite"": false,
                ""isPartOfComposite"": false
            },
            {
                ""name"": """",
                ""id"": ""b7d00e68-9ded-47bf-8bfe-b02201f0aee8"",
                ""path"": ""<HID::ACRUX SL-6632 Dark Tornado Joystick>/trigger"",
                ""interactions"": """",
                ""processors"": """",
                ""groups"": """",
                ""action"": ""TriggerButton"",
                ""isComposite"": false,
                ""isPartOfComposite"": false
            }
        ]
    }
],
""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Right = m_Gameplay.FindAction("Right", throwIfNotFound: true);
        m_Gameplay_Left = m_Gameplay.FindAction("Left", throwIfNotFound: true);
        m_Gameplay_Up = m_Gameplay.FindAction("Up", throwIfNotFound: true);
        m_Gameplay_Down = m_Gameplay.FindAction("Down", throwIfNotFound: true);
        m_Gameplay_TriggerButton = m_Gameplay.FindAction("TriggerButton", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Right;
    private readonly InputAction m_Gameplay_Left;
    private readonly InputAction m_Gameplay_Up;
    private readonly InputAction m_Gameplay_Down;
    private readonly InputAction m_Gameplay_TriggerButton;
    public struct GameplayActions
    {
        private @JoystickControlls m_Wrapper;
        public GameplayActions(@JoystickControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Right => m_Wrapper.m_Gameplay_Right;
        public InputAction @Left => m_Wrapper.m_Gameplay_Left;
        public InputAction @Up => m_Wrapper.m_Gameplay_Up;
        public InputAction @Down => m_Wrapper.m_Gameplay_Down;
        public InputAction @TriggerButton => m_Wrapper.m_Gameplay_TriggerButton;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Right.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Up.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @TriggerButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriggerButton;
                @TriggerButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriggerButton;
                @TriggerButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriggerButton;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @TriggerButton.started += instance.OnTriggerButton;
                @TriggerButton.performed += instance.OnTriggerButton;
                @TriggerButton.canceled += instance.OnTriggerButton;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnTriggerButton(InputAction.CallbackContext context);
    }
}
