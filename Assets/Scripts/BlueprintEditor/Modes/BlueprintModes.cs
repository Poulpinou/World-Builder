using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DGTools.StateMachine;

namespace WorldBuilder.Blueprints
{
	public class BlueprintModes : StateMachine
	{
        #region Events
        public class ToolEvent : UnityEvent<BlueprintMode> { }

        public ToolEvent onToolChanged = new ToolEvent();
        #endregion

        #region Properties
        public BlueprintMode CurrentTool => (BlueprintMode)currentState;
        #endregion

        #region Private Methods
        protected override void Transition(State value)
        {
            if (!typeof(BlueprintMode).IsAssignableFrom(value.GetType()))
            {
                throw new System.Exception("State should be a BlueprintMode");
            }
            base.Transition(value);
            onToolChanged.Invoke(CurrentTool);
        }
        #endregion

        
    }
}
