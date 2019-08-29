using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace WorldBuilder.Blueprints
{
    [Serializable]
	public class BlueprintDatas
	{
        public const int MAX_FLOOR_COUNT = 10;

        #region Properties
        public List<Floor> Floors { get; private set; }
        public Vector2Int Dimensions { get; private set; }
        public bool CanAddFloor {
            get {
                return Floors.Count == 0 || (Floors.Count < MAX_FLOOR_COUNT && !Floors.OrderByDescending(f => f.Number).First().IsEmpty);
            }
        }
        #endregion

        #region Constructors
        public BlueprintDatas(Vector2Int dimensions)
        {
            Dimensions = dimensions;
            Floors = new List<Floor>();
            Floors.Add(new Floor(0, Dimensions));
        }
        #endregion

        #region Public Methods
        public void AddFloor() {
            if (CanAddFloor) {
                Floors.Add(new Floor(Floors.Count, Dimensions));
                BlueprintEditor.active.grid.ChangeFloor(Floors.Count - 1);
            }
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

            public bool IsEmpty {
                get {
                    return !cells.Any(c => c.Items.Count > 0);
                }
            }
            #endregion
        }
        #endregion
    }
}
