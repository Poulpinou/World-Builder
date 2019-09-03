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

        public static BlueprintDatas ActiveDatas { get; private set; }
        #endregion

        #region Public Methods
        public void BuildBlueprint(Blueprint blueprint, int versionIndex = 0) {
            ActiveDatas = blueprint.Versions[versionIndex].datas;
            grid.SetDatas(ActiveDatas);
        }
        #endregion

        #region Runtime Methods
        private void Start()
        {
            //temp
            BuildBlueprint(new Blueprint("Test", new Vector2Int(16, 16)));
            InputManager.Map.BlueprintEditor.Enable();
            Modes.ChangeState<BlueprintMode_Foundations>();
        }
        #endregion
    }
}
