using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace WorldBuilder.Blueprints
{
    [Serializable]
	public class BlueprintDatas
	{
        #region Properties
        public List<Floor> Floors { get; private set; }
        public Vector2Int Dimensions { get; private set; }
        #endregion

        #region Constructors
        public BlueprintDatas(Vector2Int dimensions)
        {
            Dimensions = dimensions;
            Floors = new List<Floor>();
            Floors.Add(new Floor(0, Dimensions));
        }
        #endregion

        #region Insternal Classes
        [Serializable]
		public class Floor
        {
            public const int FLOOR_HEIGHT = 2;

            #region Public Variables
            public BlueprintCell[] cells;
            public List<BuildableObject> furnitures;
            #endregion

            #region Constructors
            public Floor(int floorNumber, Vector2Int dimensions)
            {
                Number = floorNumber;

                cells = new BlueprintCell[dimensions.x * dimensions.y];
                int i = 0;
                for (int x = 0; x < dimensions.x; x++)
                {
                    for (int y = 0; y < dimensions.y; y++)
                    {
                        cells[i] = new BlueprintCell(new Vector2Int(x, y), floorNumber * FLOOR_HEIGHT);
                        i++;
                    }
                }
            }
            #endregion

            #region Properties
            public int Number { get; private set; }
            #endregion
        }
        #endregion
    }
}
