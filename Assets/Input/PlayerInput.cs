//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Input/PlayerInput.inputactions
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

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""FirstPersonView"",
            ""id"": ""56f9d1d3-d1d7-457d-b508-3b5fb5459cb8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c3849642-4672-4c0b-9909-6728a76c2f13"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""2643881d-beb8-41f3-9a5d-987732edf0c2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""a5016348-6d13-401a-b20a-f13cbeea7621"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""58d0d845-578b-4d9e-969f-f99220ad8887"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2b625e4d-348d-43af-b650-2ba085a0ebce"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c4f904bc-5a79-4f68-9e50-e6e1b162d3b7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ceced26-61bd-490c-b5ad-976dc364a20f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d9d2a3e4-f44b-4a98-abef-a1a220b2d634"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""87081d9a-3a2b-4236-8cea-054adf1f45a3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""97a299a5-b99f-4820-9285-95e9fe2b80cc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22689034-690e-4d5f-9cd5-f44a6a105314"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd80ba79-a4a2-4164-b1e3-cb6214d6861d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0aef8ec6-9f5e-4836-ac7a-176f75f600e2"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8faab369-4fbc-4e54-a1d6-7daed3eabf11"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1f8f67b-f7c8-495a-90cc-658bf6593d18"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85e1364e-28ea-4d1b-b716-0db558e9fa49"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuControl"",
            ""id"": ""d16b2096-80fe-4d3a-aa19-1ec07b3f1bfb"",
            ""actions"": [
                {
                    ""name"": ""RoundValue"",
                    ""type"": ""Value"",
                    ""id"": ""86a71eb0-d103-4660-8a7e-1719903f6b16"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f227d6cb-19ab-4613-8003-0d5e8d6ebc99"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RoundValue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fe5e103-ef34-4a30-ba75-1d8c7bf93061"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RoundValue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FirstPersonView
        m_FirstPersonView = asset.FindActionMap("FirstPersonView", throwIfNotFound: true);
        m_FirstPersonView_Move = m_FirstPersonView.FindAction("Move", throwIfNotFound: true);
        m_FirstPersonView_Look = m_FirstPersonView.FindAction("Look", throwIfNotFound: true);
        m_FirstPersonView_Grab = m_FirstPersonView.FindAction("Grab", throwIfNotFound: true);
        m_FirstPersonView_Jump = m_FirstPersonView.FindAction("Jump", throwIfNotFound: true);
        // MenuControl
        m_MenuControl = asset.FindActionMap("MenuControl", throwIfNotFound: true);
        m_MenuControl_RoundValue = m_MenuControl.FindAction("RoundValue", throwIfNotFound: true);
    }

    ~@PlayerInput()
    {
        UnityEngine.Debug.Assert(!m_FirstPersonView.enabled, "This will cause a leak and performance issues, PlayerInput.FirstPersonView.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_MenuControl.enabled, "This will cause a leak and performance issues, PlayerInput.MenuControl.Disable() has not been called.");
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

    // FirstPersonView
    private readonly InputActionMap m_FirstPersonView;
    private List<IFirstPersonViewActions> m_FirstPersonViewActionsCallbackInterfaces = new List<IFirstPersonViewActions>();
    private readonly InputAction m_FirstPersonView_Move;
    private readonly InputAction m_FirstPersonView_Look;
    private readonly InputAction m_FirstPersonView_Grab;
    private readonly InputAction m_FirstPersonView_Jump;
    public struct FirstPersonViewActions
    {
        private @PlayerInput m_Wrapper;
        public FirstPersonViewActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_FirstPersonView_Move;
        public InputAction @Look => m_Wrapper.m_FirstPersonView_Look;
        public InputAction @Grab => m_Wrapper.m_FirstPersonView_Grab;
        public InputAction @Jump => m_Wrapper.m_FirstPersonView_Jump;
        public InputActionMap Get() { return m_Wrapper.m_FirstPersonView; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FirstPersonViewActions set) { return set.Get(); }
        public void AddCallbacks(IFirstPersonViewActions instance)
        {
            if (instance == null || m_Wrapper.m_FirstPersonViewActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FirstPersonViewActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Grab.started += instance.OnGrab;
            @Grab.performed += instance.OnGrab;
            @Grab.canceled += instance.OnGrab;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IFirstPersonViewActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Grab.started -= instance.OnGrab;
            @Grab.performed -= instance.OnGrab;
            @Grab.canceled -= instance.OnGrab;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IFirstPersonViewActions instance)
        {
            if (m_Wrapper.m_FirstPersonViewActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFirstPersonViewActions instance)
        {
            foreach (var item in m_Wrapper.m_FirstPersonViewActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FirstPersonViewActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FirstPersonViewActions @FirstPersonView => new FirstPersonViewActions(this);

    // MenuControl
    private readonly InputActionMap m_MenuControl;
    private List<IMenuControlActions> m_MenuControlActionsCallbackInterfaces = new List<IMenuControlActions>();
    private readonly InputAction m_MenuControl_RoundValue;
    public struct MenuControlActions
    {
        private @PlayerInput m_Wrapper;
        public MenuControlActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @RoundValue => m_Wrapper.m_MenuControl_RoundValue;
        public InputActionMap Get() { return m_Wrapper.m_MenuControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlActions set) { return set.Get(); }
        public void AddCallbacks(IMenuControlActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuControlActionsCallbackInterfaces.Add(instance);
            @RoundValue.started += instance.OnRoundValue;
            @RoundValue.performed += instance.OnRoundValue;
            @RoundValue.canceled += instance.OnRoundValue;
        }

        private void UnregisterCallbacks(IMenuControlActions instance)
        {
            @RoundValue.started -= instance.OnRoundValue;
            @RoundValue.performed -= instance.OnRoundValue;
            @RoundValue.canceled -= instance.OnRoundValue;
        }

        public void RemoveCallbacks(IMenuControlActions instance)
        {
            if (m_Wrapper.m_MenuControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuControlActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuControlActions @MenuControl => new MenuControlActions(this);
    public interface IFirstPersonViewActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IMenuControlActions
    {
        void OnRoundValue(InputAction.CallbackContext context);
    }
}
