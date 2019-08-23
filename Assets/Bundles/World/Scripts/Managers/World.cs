using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGTools;

namespace WorldBuilder.World
{
    /// <summary>
    /// Contains world informations
    /// </summary>
	public class World : StaticManager<World>
	{
        #region Serialized Variables
        [Header("World Settings")]
        [SerializeField] float worldUnitFactor = 1;
        [SerializeField] int minWorldHeight = -100;
        [SerializeField] int maxWorldHeight = 100;
        [SerializeField] Vector2 worldDimensions = new Vector2(100, 100);
        #endregion

        #region Properties
        public static int MinDepth => active.minWorldHeight;

        public static int MaxHeight => active.maxWorldHeight;

        public static float UnitFactor => active.worldUnitFactor;

        public static Vector3 Dimensions => new Vector3(
            active.worldDimensions.x, 
            active.maxWorldHeight - active.minWorldHeight, 
            active.worldDimensions.y
        );

        #endregion
    }
}
