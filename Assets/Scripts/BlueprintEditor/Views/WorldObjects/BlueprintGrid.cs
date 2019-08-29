using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder.Blueprints
{
	public class BlueprintGrid : WorldObject
	{
        #region Public Variables
        [Header("Grid Settings")]
        [SerializeField] BlueprintGridCell cellModel;
        #endregion

        #region Properties
        public int CurrentFloor { get; private set; }
        public BlueprintDatas Datas { get; private set; } 
        public BlueprintGridCell[] Cells { get; private set; }
        #endregion

        #region Public Methods
        public void SetDatas(BlueprintDatas datas)
        {
            Datas = datas;
            Clear();
            BuildGrid();
            ChangeFloor(0);
        }

        public void Clear() {
            foreach(BlueprintGridCell cell in GetComponentsInChildren<BlueprintGridCell>())
            {
                Destroy(cell.gameObject);
                Cells = null;
            }
        }

        public void ChangeFloor(int floorNumber) {
            if (floorNumber < 0) floorNumber = 0;
            if (floorNumber >= Datas.Floors.Count) floorNumber = Datas.Floors.Count - 1;

            CurrentFloor = floorNumber;
            transform.position = new Vector3(0, CurrentFloor * BlueprintDatas.Floor.FLOOR_HEIGHT, 0);

            for (int i = 0; i < Cells.Length; i++)
            {
                Cells[i].Datas = Datas.Floors[CurrentFloor].cells[i];
            }
        }
        #endregion

        #region Private Methods
        void BuildGrid() {
            for (int x = 0; x < Datas.Dimensions.x; x++)
            {
                for (int y = 0; y < Datas.Dimensions.y; y++)
                {
                    BlueprintGridCell cell = Instantiate(cellModel, transform);
                    cell.GridPos = new Vector2Int(x, y);
                }
            }

            Cells = GetComponentsInChildren<BlueprintGridCell>();
        }
        #endregion
    }
}
