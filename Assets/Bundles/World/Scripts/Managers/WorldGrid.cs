using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGTools;

namespace WorldBuilder.World
{
    /// <summary>
    /// Contains methods to help with <see cref="WorldObject"/> positions
    /// </summary>
    public class WorldGrid : StaticManager<WorldGrid>
    {
        #region Static Methods
        public static Cell GetCellFromWorldObject(WorldObject worldObject)
        {
            return GetCellFromPosition(worldObject.transform.position);
        }

        public static Cell GetCellFromPosition(Vector3 position) {
            return new Cell(new Vector2(position.x, position.z) * World.UnitFactor, position.y * World.UnitFactor);
        }
        #endregion
    }
}
