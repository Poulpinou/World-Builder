using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using WorldBuilder.Behaviours;
using WorldBuilder.Inputs;

namespace WorldBuilder.Blueprints
{
	public class BlueprintGridPositioningBehaviour : PositioningBehaviour
    {
        BlueprintCell activeCell;

        public override Type[] TypeRestrictions => new Type[] { typeof(IBlueprintCellable) };

        public override void OnRotate(InputAction.CallbackContext context)
        {
            if(context.performed)
                base.OnRotate(context);
        }

        public override void RotateTarget()
        {
            IBlueprintCellable cellable = Target as IBlueprintCellable;
            cellable.RotateOnCell(1);
        }

        protected override void FollowMouse()
        {
            BlueprintGridCell cell = InputManager.RaycastObjectFromMouse<BlueprintGridCell>(BlueprintGrid.GridLayerMask);
            if (cell != null && cell.Datas != activeCell)
            {
                activeCell = cell.Datas;
                transform.position = cell.transform.position;
                UpdateMaterial();
            }
        }

        protected override bool TargetHasValidPosition()
        {
            return activeCell.CanAdd(Target as IBlueprintCellable);
        }

        public override void ValidatePosition()
        {
            if (TargetHasValidPosition())
            {
                activeCell.AddItem(Target as IBlueprintCellable);
                Detach();
            }
        }

        public override void Cancel()
        {
            Detach();
            Destroy(Target.gameObject);
        }
    }
}
