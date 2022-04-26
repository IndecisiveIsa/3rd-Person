// GENERATED AUTOMATICALLY FROM 'Assets/_Scripts/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Locomotion"",
            ""id"": ""15f69042-df1c-4573-b605-5c823d86720f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""13d25f1b-5c42-4659-a0e4-30c83d09a903"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""912cf0e6-6dba-46b8-a061-d521faba36b0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""929c66cb-134a-46a7-b318-6830a0bd9635"",
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
                    ""id"": ""b8ef0cbb-e7fa-46ed-b21e-5a823a55dc78"",
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
                    ""id"": ""d9fe9f20-8beb-4699-b5e9-8d5bdcd5d7d4"",
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
                    ""id"": ""c9afc5a8-3abe-46ed-bc8e-4f13e236279a"",
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
                    ""id"": ""c23361ec-e1be-42a5-9673-e9c271a133c1"",
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
                    ""id"": ""a1d6df60-fca9-4bcf-b1a5-bb823562bdd1"",
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
    ""controlSchemes"": []
}");
        // Locomotion
        m_Locomotion = asset.FindActionMap("Locomotion", throwIfNotFound: true);
        m_Locomotion_Move = m_Locomotion.FindAction("Move", throwIfNotFound: true);
        m_Locomotion_Look = m_Locomotion.FindAction("Look", throwIfNotFound: true);
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

    // Locomotion
    private readonly InputActionMap m_Locomotion;
    private ILocomotionActions m_LocomotionActionsCallbackInterface;
    private readonly InputAction m_Locomotion_Move;
    private readonly InputAction m_Locomotion_Look;
    public struct LocomotionActions
    {
        private @Controls m_Wrapper;
        public LocomotionActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Locomotion_Move;
        public InputAction @Look => m_Wrapper.m_Locomotion_Look;
        public InputActionMap Get() { return m_Wrapper.m_Locomotion; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LocomotionActions set) { return set.Get(); }
        public void SetCallbacks(ILocomotionActions instance)
        {
            if (m_Wrapper.m_LocomotionActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_LocomotionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public LocomotionActions @Locomotion => new LocomotionActions(this);
    public interface ILocomotionActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
