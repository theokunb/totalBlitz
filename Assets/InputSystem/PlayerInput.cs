//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSystem/PlayerInput.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""067ef782-61f7-4b56-89d6-5412c8e4f86b"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Value"",
                    ""id"": ""97d87ab8-2bc0-48c7-91e7-b7d67db35a14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Value"",
                    ""id"": ""902ade22-c55b-450d-92ba-3852a88b504a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Value"",
                    ""id"": ""7af1dfe3-ef73-427f-ba63-0311804b99b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Value"",
                    ""id"": ""44d3fe65-66d7-4c21-8201-52ab58a49291"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""a3607973-b29c-48d6-8c8f-155d77c612ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d323b0b1-66f7-44b1-8e45-708b7af30ee5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1fe829c-b088-4eae-91f3-d5b9c25acfd0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb5c36d8-704e-4cc4-bd85-2a226fee8f4f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b648d6b-ad66-40a0-9a83-354a5082a3ad"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""753c3673-b8fb-401e-9946-320c37fa5a54"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""53bb7f12-ba08-4859-a65d-bea40bb1b19a"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""3516a681-9856-4048-9af2-5a95c683192f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3d492383-0a76-47cf-9f8b-f83bcc891ac9"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlayerInput"",
            ""bindingGroup"": ""PlayerInput"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Forward = m_Player.FindAction("Forward", throwIfNotFound: true);
        m_Player_Back = m_Player.FindAction("Back", throwIfNotFound: true);
        m_Player_Left = m_Player.FindAction("Left", throwIfNotFound: true);
        m_Player_Right = m_Player.FindAction("Right", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Look = m_Mouse.FindAction("Look", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Forward;
    private readonly InputAction m_Player_Back;
    private readonly InputAction m_Player_Left;
    private readonly InputAction m_Player_Right;
    private readonly InputAction m_Player_Pause;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Player_Forward;
        public InputAction @Back => m_Wrapper.m_Player_Back;
        public InputAction @Left => m_Wrapper.m_Player_Left;
        public InputAction @Right => m_Wrapper.m_Player_Right;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Back.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBack;
                @Left.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_Look;
    public struct MouseActions
    {
        private @PlayerInput m_Wrapper;
        public MouseActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_Mouse_Look;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @Look.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    private int m_PlayerInputSchemeIndex = -1;
    public InputControlScheme PlayerInputScheme
    {
        get
        {
            if (m_PlayerInputSchemeIndex == -1) m_PlayerInputSchemeIndex = asset.FindControlSchemeIndex("PlayerInput");
            return asset.controlSchemes[m_PlayerInputSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnLook(InputAction.CallbackContext context);
    }
}
