// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/InputMap/InputMap.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace WorldBuilder.Inputs
{
    public class InputMap : IInputActionCollection
    {
        private InputActionAsset asset;
        public InputMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""BlueprintEditor"",
            ""id"": ""e5eaf002-79cb-46ca-86a1-779ab9db6315"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""46c4147e-6a53-49d3-bd51-5dd4e4da62a4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""434099e7-24c2-4c43-9834-fc479e85de9f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""d729ce1d-3e2a-4444-a1ce-e4ba0487c011"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5bbe5cfc-485a-43f4-9b7e-a6edaebd2433"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Computer"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""886058ad-a100-4a9e-9a86-d48dc94c1259"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Computer"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62ae1e0e-425b-493e-80cf-7181047ebd8e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23ceb244-77ab-4345-a84b-d7f85e7cf5ba"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""347e4142-31ea-4a62-9b91-fc84feedb7aa"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""WorldObjects"",
            ""id"": ""50f5ab56-0229-4229-9f2d-704952029d41"",
            ""actions"": [
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""4f4183f3-61b6-48a8-985f-ea4fe6885448"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""ad097d2a-6cd6-4dc1-b4d4-86c0da3536ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eab0266d-a2af-43d2-a4a9-2d29153ceaf9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96c946d7-135f-4a83-814a-bcb90de5175c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Computer"",
            ""basedOn"": """",
            ""bindingGroup"": ""Computer"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // BlueprintEditor
            m_BlueprintEditor = asset.GetActionMap("BlueprintEditor");
            m_BlueprintEditor_Confirm = m_BlueprintEditor.GetAction("Confirm");
            m_BlueprintEditor_Cancel = m_BlueprintEditor.GetAction("Cancel");
            m_BlueprintEditor_Rotate = m_BlueprintEditor.GetAction("Rotate");
            // WorldObjects
            m_WorldObjects = asset.GetActionMap("WorldObjects");
            m_WorldObjects_LeftClick = m_WorldObjects.GetAction("LeftClick");
            m_WorldObjects_RightClick = m_WorldObjects.GetAction("RightClick");
        }

        ~InputMap()
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

        // BlueprintEditor
        private readonly InputActionMap m_BlueprintEditor;
        private IBlueprintEditorActions m_BlueprintEditorActionsCallbackInterface;
        private readonly InputAction m_BlueprintEditor_Confirm;
        private readonly InputAction m_BlueprintEditor_Cancel;
        private readonly InputAction m_BlueprintEditor_Rotate;
        public struct BlueprintEditorActions
        {
            private InputMap m_Wrapper;
            public BlueprintEditorActions(InputMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Confirm => m_Wrapper.m_BlueprintEditor_Confirm;
            public InputAction @Cancel => m_Wrapper.m_BlueprintEditor_Cancel;
            public InputAction @Rotate => m_Wrapper.m_BlueprintEditor_Rotate;
            public InputActionMap Get() { return m_Wrapper.m_BlueprintEditor; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(BlueprintEditorActions set) { return set.Get(); }
            public void SetCallbacks(IBlueprintEditorActions instance)
            {
                if (m_Wrapper.m_BlueprintEditorActionsCallbackInterface != null)
                {
                    Confirm.started -= m_Wrapper.m_BlueprintEditorActionsCallbackInterface.OnConfirm;
                    Confirm.performed -= m_Wrapper.m_BlueprintEditorActionsCallbackInterface.OnConfirm;
                    Confirm.canceled -= m_Wrapper.m_BlueprintEditorActionsCallbackInterface.OnConfirm;
                    Cancel.started -= m_Wrapper.m_BlueprintEditorActionsCallbackInterface.OnCancel;
                    Cancel.performed -= m_Wrapper.m_BlueprintEditorActionsCallbackInterface.OnCancel;
                    Cancel.canceled -= m_Wrapper.m_BlueprintEditorActionsCallbackInterface.OnCancel;
                    Rotate.started -= m_Wrapper.m_BlueprintEditorActionsCallbackInterface.OnRotate;
                    Rotate.performed -= m_Wrapper.m_BlueprintEditorActionsCallbackInterface.OnRotate;
                    Rotate.canceled -= m_Wrapper.m_BlueprintEditorActionsCallbackInterface.OnRotate;
                }
                m_Wrapper.m_BlueprintEditorActionsCallbackInterface = instance;
                if (instance != null)
                {
                    Confirm.started += instance.OnConfirm;
                    Confirm.performed += instance.OnConfirm;
                    Confirm.canceled += instance.OnConfirm;
                    Cancel.started += instance.OnCancel;
                    Cancel.performed += instance.OnCancel;
                    Cancel.canceled += instance.OnCancel;
                    Rotate.started += instance.OnRotate;
                    Rotate.performed += instance.OnRotate;
                    Rotate.canceled += instance.OnRotate;
                }
            }
        }
        public BlueprintEditorActions @BlueprintEditor => new BlueprintEditorActions(this);

        // WorldObjects
        private readonly InputActionMap m_WorldObjects;
        private IWorldObjectsActions m_WorldObjectsActionsCallbackInterface;
        private readonly InputAction m_WorldObjects_LeftClick;
        private readonly InputAction m_WorldObjects_RightClick;
        public struct WorldObjectsActions
        {
            private InputMap m_Wrapper;
            public WorldObjectsActions(InputMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @LeftClick => m_Wrapper.m_WorldObjects_LeftClick;
            public InputAction @RightClick => m_Wrapper.m_WorldObjects_RightClick;
            public InputActionMap Get() { return m_Wrapper.m_WorldObjects; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(WorldObjectsActions set) { return set.Get(); }
            public void SetCallbacks(IWorldObjectsActions instance)
            {
                if (m_Wrapper.m_WorldObjectsActionsCallbackInterface != null)
                {
                    LeftClick.started -= m_Wrapper.m_WorldObjectsActionsCallbackInterface.OnLeftClick;
                    LeftClick.performed -= m_Wrapper.m_WorldObjectsActionsCallbackInterface.OnLeftClick;
                    LeftClick.canceled -= m_Wrapper.m_WorldObjectsActionsCallbackInterface.OnLeftClick;
                    RightClick.started -= m_Wrapper.m_WorldObjectsActionsCallbackInterface.OnRightClick;
                    RightClick.performed -= m_Wrapper.m_WorldObjectsActionsCallbackInterface.OnRightClick;
                    RightClick.canceled -= m_Wrapper.m_WorldObjectsActionsCallbackInterface.OnRightClick;
                }
                m_Wrapper.m_WorldObjectsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    LeftClick.started += instance.OnLeftClick;
                    LeftClick.performed += instance.OnLeftClick;
                    LeftClick.canceled += instance.OnLeftClick;
                    RightClick.started += instance.OnRightClick;
                    RightClick.performed += instance.OnRightClick;
                    RightClick.canceled += instance.OnRightClick;
                }
            }
        }
        public WorldObjectsActions @WorldObjects => new WorldObjectsActions(this);
        private int m_ComputerSchemeIndex = -1;
        public InputControlScheme ComputerScheme
        {
            get
            {
                if (m_ComputerSchemeIndex == -1) m_ComputerSchemeIndex = asset.GetControlSchemeIndex("Computer");
                return asset.controlSchemes[m_ComputerSchemeIndex];
            }
        }
        public interface IBlueprintEditorActions
        {
            void OnConfirm(InputAction.CallbackContext context);
            void OnCancel(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
        }
        public interface IWorldObjectsActions
        {
            void OnLeftClick(InputAction.CallbackContext context);
            void OnRightClick(InputAction.CallbackContext context);
        }
    }
}
