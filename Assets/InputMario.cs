// GENERATED AUTOMATICALLY FROM 'Assets/InputMario.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMario : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMario()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMario"",
    ""maps"": [
        {
            ""name"": ""Main controller"",
            ""id"": ""a5ae7195-b333-428c-aeeb-c40ce03291c2"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""71b6c3cb-0a90-4dec-aa8e-66f7c2f22969"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ab716293-1528-41d8-b75e-47c586f6f566"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""301ae651-2347-4fa4-83da-77c1fd5ae5bb"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""pad"",
                    ""id"": ""068f7886-69ab-43a7-bcca-dc420b2df1b4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e632b876-caf3-4d18-83e1-307c0eabb2d7"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d7f77945-69d0-4bcc-a585-0f540dc2dcb4"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bf052f42-7a04-4a94-b812-0e2cb3474512"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dd98478e-2153-436d-980c-5b48a9a4daa4"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""keys"",
                    ""id"": ""d9951d90-ed38-4c2d-bf78-f63149c68364"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e6e13362-b053-47e2-9c06-80c12d5a0dda"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9b922561-cbac-494d-b36f-e977c90c375d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""18f54b34-6f88-4479-abba-a8cb57957272"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8d067e6f-926a-45fc-94d3-42876e1da02f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Main controller
        m_Maincontroller = asset.FindActionMap("Main controller", throwIfNotFound: true);
        m_Maincontroller_Movement = m_Maincontroller.FindAction("Movement", throwIfNotFound: true);
        m_Maincontroller_Jump = m_Maincontroller.FindAction("Jump", throwIfNotFound: true);
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

    // Main controller
    private readonly InputActionMap m_Maincontroller;
    private IMaincontrollerActions m_MaincontrollerActionsCallbackInterface;
    private readonly InputAction m_Maincontroller_Movement;
    private readonly InputAction m_Maincontroller_Jump;
    public struct MaincontrollerActions
    {
        private @InputMario m_Wrapper;
        public MaincontrollerActions(@InputMario wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Maincontroller_Movement;
        public InputAction @Jump => m_Wrapper.m_Maincontroller_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Maincontroller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MaincontrollerActions set) { return set.Get(); }
        public void SetCallbacks(IMaincontrollerActions instance)
        {
            if (m_Wrapper.m_MaincontrollerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MaincontrollerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MaincontrollerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MaincontrollerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_MaincontrollerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MaincontrollerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MaincontrollerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_MaincontrollerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public MaincontrollerActions @Maincontroller => new MaincontrollerActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IMaincontrollerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}