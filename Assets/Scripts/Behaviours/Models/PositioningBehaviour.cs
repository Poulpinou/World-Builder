using System;
using UnityEngine;
using WorldBuilder.Inputs;
using UnityEngine.InputSystem;

namespace WorldBuilder.Behaviours
{
    public class PositioningBehaviour : Behaviour, InputMap.IBlueprintEditorActions
    {
        #region Properties
        public override Type[] TypeRestrictions => new Type[] { typeof(WorldObject) };

        public override UnicityConstraintType UnicityConstraint => UnicityConstraintType.unique;

        public new WorldObject Target => base.Target as WorldObject;

        public Transform InitialTransform { get; protected set; }
        #endregion

        #region Public Methods
        public virtual void RotateTarget()
        {
            Target.transform.eulerAngles += new Vector3(0, 15 * Time.deltaTime, 0);
        }

        public virtual void ValidatePosition()
        {
            if (TargetHasValidPosition())
            {
                Detach();
            }
        }

        public virtual void Cancel()
        {
            Target.transform.position = InitialTransform.position;
            Target.transform.rotation = InitialTransform.rotation;
            Detach();
        }
        #endregion

        #region Private Methods
        protected override void Enter()
        {
            InitialTransform = Target.transform;
            InputManager.Map.BlueprintEditor.SetCallbacks(this);
            Target.AttachBehaviour<TempMaterialBehaviour, Material>(GameSettings.Settings.validMaterial, this);
        }

        protected override void Exit()
        {
            InputManager.Map.BlueprintEditor.SetCallbacks(null);
            Target.DetachAllBehaviours(this);
        }

        protected virtual void FollowMouse() {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Target.transform.position = hit.point;
                UpdateMaterial();
            }
        }

        protected virtual void UpdateMaterial() {
            TempMaterialBehaviour behaviour = Target.GetBehaviour<TempMaterialBehaviour>();
            if (behaviour != null) {
                behaviour.ChangeMaterial(TargetHasValidPosition() ? GameSettings.Settings.validMaterial : GameSettings.Settings.invalidMaterial);
            }
        }

        protected virtual bool TargetHasValidPosition()
        {
            return true;
        }
        #endregion

        #region Input Callbacks
        public virtual void OnConfirm(InputAction.CallbackContext context)
        {
            if (context.performed == true)
            {
                ValidatePosition();
            }
        }

        public virtual void OnCancel(InputAction.CallbackContext context)
        {
            if (context.performed == true)
                Cancel();
        }

        public virtual void OnRotate(InputAction.CallbackContext context)
        {
            RotateTarget();
        }
        #endregion

        #region Runtime Methods
        protected virtual void Update()
        {
            FollowMouse();
        }
        #endregion
    }
}
