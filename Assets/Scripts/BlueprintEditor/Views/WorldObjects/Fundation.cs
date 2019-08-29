using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldBuilder.Blueprints;

namespace WorldBuilder
{
    public class Fundation : BuildableObject, IBlueprintCellable
    {
        #region Public Variables
        [Header("Cell constraints")]
        [SerializeField] BlueprintCellSlot cellSlot;
        //[SerializeField] BlueprintCellAnchor cellAnchor;
        #endregion

        #region Properties
        public BlueprintCellSlot CellSlot {
            get => cellSlot;
            set => cellSlot = value;
        }
        //public BlueprintCellAnchor CellAnchor { get; set; }
        #endregion
    }
}
