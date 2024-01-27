// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Input"",
            ""id"": ""4425b1bd-6f9a-4ee5-8085-1ff1829479d0"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1bb3ff3e-7ce2-45cf-ac08-733c9d8bb57b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftShift"",
                    ""type"": ""Button"",
                    ""id"": ""7856b201-28e0-4915-ae0d-4268f3028287"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMouse"",
                    ""type"": ""Button"",
                    ""id"": ""d75bc65a-c111-49e8-8491-891d2fc5c4a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMouse"",
                    ""type"": ""Button"",
                    ""id"": ""02f8562f-bb28-4390-bb9e-b48c6a0bbd09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleMouse"",
                    ""type"": ""Button"",
                    ""id"": ""e03f2d9e-c192-427f-8fde-2c640819cc5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""E"",
                    ""type"": ""Button"",
                    ""id"": ""8280205d-3d42-4978-92ab-4ec91147b54e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""3b665874-2f47-4a00-8379-53e0d91a17e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseScroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1d11db53-5bac-48ee-8009-116823120ad4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""wasd"",
                    ""id"": ""26ff3a62-313b-41b1-ba4f-2f318d24b3d4"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cd13490e-72b7-483c-93d8-10b8db1d41bb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""98d15961-5116-442b-ba17-9083e26cb51a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""16812541-026a-4048-afa4-988e9be6a3a0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2d3ea829-1528-4cf5-a990-c5dc09aba1e5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a36652b3-a993-4bf9-9a02-bd3021bf627c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftShift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c84b5b2-6e77-4f01-b2f4-387192e8c9c5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a5f0fa0-799d-4e77-a230-af554da9c3c6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d97cb3e9-0a16-43a4-adf1-23fd97a1ef2e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e23f3bc4-ff1a-4137-be6e-61080e4efba2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e87806b-f83c-4506-95f5-c203343c57d1"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9206542c-55f1-40fc-97cf-d7ae591f30ed"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MiddleMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": []
        }
    ]
}");
        // Input
        m_Input = asset.FindActionMap("Input", throwIfNotFound: true);
        m_Input_Movement = m_Input.FindAction("Movement", throwIfNotFound: true);
        m_Input_LeftShift = m_Input.FindAction("LeftShift", throwIfNotFound: true);
        m_Input_LeftMouse = m_Input.FindAction("LeftMouse", throwIfNotFound: true);
        m_Input_RightMouse = m_Input.FindAction("RightMouse", throwIfNotFound: true);
        m_Input_MiddleMouse = m_Input.FindAction("MiddleMouse", throwIfNotFound: true);
        m_Input_E = m_Input.FindAction("E", throwIfNotFound: true);
        m_Input_Space = m_Input.FindAction("Space", throwIfNotFound: true);
        m_Input_MouseScroll = m_Input.FindAction("MouseScroll", throwIfNotFound: true);
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

    // Input
    private readonly InputActionMap m_Input;
    private IInputActions m_InputActionsCallbackInterface;
    private readonly InputAction m_Input_Movement;
    private readonly InputAction m_Input_LeftShift;
    private readonly InputAction m_Input_LeftMouse;
    private readonly InputAction m_Input_RightMouse;
    private readonly InputAction m_Input_MiddleMouse;
    private readonly InputAction m_Input_E;
    private readonly InputAction m_Input_Space;
    private readonly InputAction m_Input_MouseScroll;
    public struct InputActions
    {
        private @InputControls m_Wrapper;
        public InputActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Input_Movement;
        public InputAction @LeftShift => m_Wrapper.m_Input_LeftShift;
        public InputAction @LeftMouse => m_Wrapper.m_Input_LeftMouse;
        public InputAction @RightMouse => m_Wrapper.m_Input_RightMouse;
        public InputAction @MiddleMouse => m_Wrapper.m_Input_MiddleMouse;
        public InputAction @E => m_Wrapper.m_Input_E;
        public InputAction @Space => m_Wrapper.m_Input_Space;
        public InputAction @MouseScroll => m_Wrapper.m_Input_MouseScroll;
        public InputActionMap Get() { return m_Wrapper.m_Input; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputActions set) { return set.Get(); }
        public void SetCallbacks(IInputActions instance)
        {
            if (m_Wrapper.m_InputActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement;
                @LeftShift.started -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftShift;
                @LeftShift.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftShift;
                @LeftShift.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftShift;
                @LeftMouse.started -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftMouse;
                @LeftMouse.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftMouse;
                @LeftMouse.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftMouse;
                @RightMouse.started -= m_Wrapper.m_InputActionsCallbackInterface.OnRightMouse;
                @RightMouse.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnRightMouse;
                @RightMouse.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnRightMouse;
                @MiddleMouse.started -= m_Wrapper.m_InputActionsCallbackInterface.OnMiddleMouse;
                @MiddleMouse.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnMiddleMouse;
                @MiddleMouse.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnMiddleMouse;
                @E.started -= m_Wrapper.m_InputActionsCallbackInterface.OnE;
                @E.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnE;
                @E.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnE;
                @Space.started -= m_Wrapper.m_InputActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnSpace;
                @MouseScroll.started -= m_Wrapper.m_InputActionsCallbackInterface.OnMouseScroll;
                @MouseScroll.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnMouseScroll;
                @MouseScroll.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnMouseScroll;
            }
            m_Wrapper.m_InputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @LeftShift.started += instance.OnLeftShift;
                @LeftShift.performed += instance.OnLeftShift;
                @LeftShift.canceled += instance.OnLeftShift;
                @LeftMouse.started += instance.OnLeftMouse;
                @LeftMouse.performed += instance.OnLeftMouse;
                @LeftMouse.canceled += instance.OnLeftMouse;
                @RightMouse.started += instance.OnRightMouse;
                @RightMouse.performed += instance.OnRightMouse;
                @RightMouse.canceled += instance.OnRightMouse;
                @MiddleMouse.started += instance.OnMiddleMouse;
                @MiddleMouse.performed += instance.OnMiddleMouse;
                @MiddleMouse.canceled += instance.OnMiddleMouse;
                @E.started += instance.OnE;
                @E.performed += instance.OnE;
                @E.canceled += instance.OnE;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
                @MouseScroll.started += instance.OnMouseScroll;
                @MouseScroll.performed += instance.OnMouseScroll;
                @MouseScroll.canceled += instance.OnMouseScroll;
            }
        }
    }
    public InputActions @Input => new InputActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IInputActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLeftShift(InputAction.CallbackContext context);
        void OnLeftMouse(InputAction.CallbackContext context);
        void OnRightMouse(InputAction.CallbackContext context);
        void OnMiddleMouse(InputAction.CallbackContext context);
        void OnE(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
        void OnMouseScroll(InputAction.CallbackContext context);
    }
}
