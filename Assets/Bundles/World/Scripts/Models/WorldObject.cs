using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldBuilder.World;

namespace WorldBuilder
{
    /// <summary>
    /// The main class for every scene objects
    /// </summary>
	public abstract class WorldObject : MonoBehaviour
	{
        #region Properties
        public Cell currentCell => WorldGrid.GetCellFromWorldObject(this);
        #endregion
    }
}
