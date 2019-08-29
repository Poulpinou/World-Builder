using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace WorldBuilder.Blueprints
{
    public enum BlueprintCellSlot {
        center = 0,
        edgeN = 10,
        edgeE = 11,
        edgeS = 12,
        edgeW = 13,
        cornerNE = 20,
        cornerSE = 21,
        cornerSW = 22,
        cornerNW = 23
    }

    //public enum BlueprintCellAnchor {full, midUp, midDown}

    [Serializable]
    public class BlueprintCell
	{
        #region Private Variables
        List<IBlueprintCellable> items;
        #endregion

        #region Properties
        public Vector2Int GridPos { get; private set; }
        public int Height { get; private set; }
        public Vector3 Position => new Vector3(GridPos.x, Height, GridPos.y);
        #endregion

        #region Construtors
        public BlueprintCell(Vector2Int gridPos, int height)
        {
            GridPos = gridPos;
            Height = height;
            items = new List<IBlueprintCellable>();
        }
        #endregion

        #region Public Methods
        public bool CanAdd(IBlueprintCellable item)
        {
            return !items.Any(i => i.CellSlot == item.CellSlot);
        }

        public void AddItem(IBlueprintCellable item, bool force = false)
        {
            if (CanAdd(item))
            {
                items.Add(item);
            }
            else if (force)
            {
                RemoveAtSlot(item.CellSlot);
                items.Add(item);
            }
        }

        public void RemoveAtSlot(BlueprintCellSlot slot)
        {
            items.RemoveAll(i => i.CellSlot == slot);
        }

        public void RemoveItem(IBlueprintCellable item)
        {
            if (items.Contains(item))
                items.Remove(item);
        }
        #endregion
    }
}
