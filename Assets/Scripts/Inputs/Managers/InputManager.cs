using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DGTools;

namespace WorldBuilder.Inputs
{
	public class InputManager : StaticManager<InputManager>, InputMap.IWorldObjectsActions
	{
        #region Private Variables
        InputMap inputMap;
        #endregion

        #region Events
        public static WorldObjectEvent onWorldObjectLeftClick = new WorldObjectEvent();
        public static WorldObjectEvent onWorldObjectRightClick = new WorldObjectEvent();
        #endregion

        #region Properties
        public static InputMap Map => active.inputMap;
        #endregion

        #region Static Methods
        public static TObject RaycastObjectFromMouse<TObject>(int? layerMask = null) where TObject : WorldObject {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(layerMask.HasValue? Physics.Raycast(ray, out hit, 1000, layerMask.Value) : Physics.Raycast(ray, out hit)){
                if(hit.collider != null)
                {
                    TObject obj = hit.collider.GetComponent<TObject>();
                    return obj;
                }
            }
            return default;
        }
        #endregion

        #region Input Callbacks
        public void OnLeftClick(InputAction.CallbackContext context)
        {
            WorldObject worldObject = RaycastObjectFromMouse<WorldObject>();
            if (worldObject != null)
                onWorldObjectLeftClick.Invoke(worldObject);
        }

        public void OnRightClick(InputAction.CallbackContext context)
        {
            WorldObject worldObject = RaycastObjectFromMouse<WorldObject>();
            if (worldObject != null)
                onWorldObjectRightClick.Invoke(worldObject);
        }
        #endregion

        #region Runtime Methods
        protected override void Awake()
        {
            base.Awake();
            inputMap = new InputMap();
            inputMap.WorldObjects.SetCallbacks(this);
        }
        #endregion
    }
}
