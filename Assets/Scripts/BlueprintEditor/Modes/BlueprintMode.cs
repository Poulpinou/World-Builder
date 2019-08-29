using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGTools.StateMachine;
using DGTools.UI;
using WorldBuilder.Libraries;
using WorldBuilder.Behaviours;
using WorldBuilder.Inputs;

namespace WorldBuilder.Blueprints
{
    public abstract class BlueprintMode : State
    {
        protected override void AddListeners()
        {
        }

        protected override void RemoveListeners()
        {
        }
    }

    public class BlueprintMode_Foundations : BlueprintMode
    {
        BuildableObject selected;
        PositioningBehaviour activeBehaviour;

        protected override void AddListeners()
        {
            LibraryContentDisplay libDisplay = BlueprintEditor.active.editorMenu.libraryDisplay;
            libDisplay.Show();
            libDisplay.Library = LibrariesManager.GetLibrary<BuildableObjectLibrary>("Demo");
            libDisplay.OnGridSelect.AddListener(OnLibraryItemSelect);
        }

        protected override void RemoveListeners()
        {
            LibraryContentDisplay libDisplay = BlueprintEditor.active.editorMenu.libraryDisplay;
            libDisplay.Hide();
            libDisplay.OnGridSelect.RemoveListener(OnLibraryItemSelect);
        }

        void OnLibraryItemSelect(UITile tile) {
            if(activeBehaviour != null)
            {
                activeBehaviour.Cancel();
            }

            BuildableObject inst = Instantiate((BuildableObject)tile.item);
            activeBehaviour = inst.AttachBehaviour<BlueprintGridPositioningBehaviour>(this);
        }
    }

    public class BlueprintMode_Decoration : BlueprintMode
    {

    }

    public class BlueprintMode_Furniture : BlueprintMode
    {

    }
}
