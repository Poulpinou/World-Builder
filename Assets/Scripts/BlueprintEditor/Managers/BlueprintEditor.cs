using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGTools;
using WorldBuilder.Inputs;

namespace WorldBuilder.Blueprints
{
    [RequireComponent(typeof(BlueprintModes))]
	public class BlueprintEditor : StaticManager<BlueprintEditor>
	{
        #region Public Variables
        public BlueprintEditorMenu editorMenu;
        public BlueprintGrid grid;
        #endregion

        #region Properties
        public static BlueprintModes Modes => active.GetComponent<BlueprintModes>();
        #endregion

        #region Public Methods
        public void BuildBlueprint(Blueprint blueprint, int versionIndex = 0) {
            grid.SetDatas(blueprint.Versions[versionIndex].datas);
        }
        #endregion

        #region Runtime Methods
        private void Start()
        {
            //temp
            BuildBlueprint(new Blueprint("Test", new Vector2Int(32, 32)));
            InputManager.Map.BlueprintEditor.Enable();
            Modes.ChangeState<BlueprintMode_Foundations>();
        }
        #endregion
    }
}
