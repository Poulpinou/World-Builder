using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder.Blueprints
{
    public interface IBlueprintCellable
    {
        BlueprintCellSlot CellSlot { get; set; }
        //BlueprintCellAnchor CellAnchor { get; set; }
    }

    public static class BlueprintCellableExtentions {

        public static void SetToNextSlot(this IBlueprintCellable cellable) {
            if (cellable.CellSlot == BlueprintCellSlot.center) return;

            int slot = (int)cellable.CellSlot;

            if (slot >= 10 && slot < 20)
            {
                slot++;    
                if (slot > 13) slot = 10;
            }
            else if(slot >= 20)
            {
                slot++;
                if (slot > 23) slot = 20;
            }

            cellable.CellSlot = (BlueprintCellSlot)slot;
        }

        public static void SetToPreviousSlot(this IBlueprintCellable cellable)
        {
            if (cellable.CellSlot == BlueprintCellSlot.center) return;

            int slot = (int)cellable.CellSlot;

            if (slot >= 10 && slot < 20)
            {
                slot--;
                if (slot < 10) slot = 13;
            }
            else if (slot >= 20)
            {
                slot--;
                if (slot < 20) slot = 23;
            }

            cellable.CellSlot = (BlueprintCellSlot)slot;
        }
    }
}
