//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/inputs/PlayerInputs.inputactions
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

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""722ca761-d876-4cb4-8d57-f02b3a0484a2"",
            ""actions"": [
                {
                    ""name"": ""LeftRight"",
                    ""type"": ""Button"",
                    ""id"": ""d82e1d30-cd24-4dff-97a8-7d97ad343415"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActionPrimary"",
                    ""type"": ""Button"",
                    ""id"": ""7c74e3f7-cc2f-4779-bbf7-d64e6182cc9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActionSecondary"",
                    ""type"": ""Button"",
                    ""id"": ""3eba6dcc-be1a-477b-9587-513509716849"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActionTirtiary"",
                    ""type"": ""Button"",
                    ""id"": ""42aa979b-0324-4321-9057-d1682943db66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD"",
                    ""id"": ""f2e20ef4-13a0-4b52-af8d-d2f203ca0586"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b03ba645-5741-493b-8eb1-9a44229033b7"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e2e77234-d2c2-453b-b014-e064071d7588"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d6a9e6d2-838e-4a88-a4a2-50c07ce281fb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d01ff99c-9e3d-424e-b4f6-9b9d34c1cc36"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2820db74-7396-43eb-b145-4e88892734c7"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e94d7238-7ea3-4409-bd3f-488121d1d04c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d152d1da-5254-4629-a772-55bfadea4819"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e20f722-6012-46ea-abb5-8e2de6d180de"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionSecondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7eefc95b-72d3-49e7-90e3-55bd2e871898"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionSecondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6b602b3-4535-49d3-becd-84130b58489d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionTirtiary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1fd175a-7500-43cd-ab92-0e6358497910"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionTirtiary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_LeftRight = m_Player.FindAction("LeftRight", throwIfNotFound: true);
        m_Player_ActionPrimary = m_Player.FindAction("ActionPrimary", throwIfNotFound: true);
        m_Player_ActionSecondary = m_Player.FindAction("ActionSecondary", throwIfNotFound: true);
        m_Player_ActionTirtiary = m_Player.FindAction("ActionTirtiary", throwIfNotFound: true);
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
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_LeftRight;
    private readonly InputAction m_Player_ActionPrimary;
    private readonly InputAction m_Player_ActionSecondary;
    private readonly InputAction m_Player_ActionTirtiary;
    public struct PlayerActions
    {
        private @PlayerInputs m_Wrapper;
        public PlayerActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftRight => m_Wrapper.m_Player_LeftRight;
        public InputAction @ActionPrimary => m_Wrapper.m_Player_ActionPrimary;
        public InputAction @ActionSecondary => m_Wrapper.m_Player_ActionSecondary;
        public InputAction @ActionTirtiary => m_Wrapper.m_Player_ActionTirtiary;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @LeftRight.started += instance.OnLeftRight;
            @LeftRight.performed += instance.OnLeftRight;
            @LeftRight.canceled += instance.OnLeftRight;
            @ActionPrimary.started += instance.OnActionPrimary;
            @ActionPrimary.performed += instance.OnActionPrimary;
            @ActionPrimary.canceled += instance.OnActionPrimary;
            @ActionSecondary.started += instance.OnActionSecondary;
            @ActionSecondary.performed += instance.OnActionSecondary;
            @ActionSecondary.canceled += instance.OnActionSecondary;
            @ActionTirtiary.started += instance.OnActionTirtiary;
            @ActionTirtiary.performed += instance.OnActionTirtiary;
            @ActionTirtiary.canceled += instance.OnActionTirtiary;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @LeftRight.started -= instance.OnLeftRight;
            @LeftRight.performed -= instance.OnLeftRight;
            @LeftRight.canceled -= instance.OnLeftRight;
            @ActionPrimary.started -= instance.OnActionPrimary;
            @ActionPrimary.performed -= instance.OnActionPrimary;
            @ActionPrimary.canceled -= instance.OnActionPrimary;
            @ActionSecondary.started -= instance.OnActionSecondary;
            @ActionSecondary.performed -= instance.OnActionSecondary;
            @ActionSecondary.canceled -= instance.OnActionSecondary;
            @ActionTirtiary.started -= instance.OnActionTirtiary;
            @ActionTirtiary.performed -= instance.OnActionTirtiary;
            @ActionTirtiary.canceled -= instance.OnActionTirtiary;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnLeftRight(InputAction.CallbackContext context);
        void OnActionPrimary(InputAction.CallbackContext context);
        void OnActionSecondary(InputAction.CallbackContext context);
        void OnActionTirtiary(InputAction.CallbackContext context);
    }
}
