using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder.Blueprints
{
	public class BlueprintGridCell : WorldObject
	{
        #region Public Variables
        [Header("Cell Settings")]
        [SerializeField] Texture2D activeTexture;
        [SerializeField] Texture2D inactiveTexture;
        #endregion

        #region Private Variables
        bool mouseOver = false;
        BlueprintCell datas;
        Vector2Int gridPos;
        #endregion

        #region Properties
        public bool IsMouseOver {
            get => mouseOver;
            set {
                if (value != mouseOver) {
                    mouseOver = value;
                    GetComponent<Renderer>().material.SetTexture("_MainTex", mouseOver ? activeTexture : inactiveTexture);
                }
            }
        }

        public BlueprintCell Datas
        {
            get => datas;
            set {
                datas = value;
                GridPos = datas.GridPos;
            }
        }

        public Vector2Int GridPos {
            get => gridPos;
            set {
                gridPos = value;
                transform.localPosition = new Vector3(gridPos.x, 0, gridPos.y);
            }
        }
        #endregion

        #region Runtime Methods
        public void OnMouseOver()
        {
            IsMouseOver = true;
        }

        private void OnMouseExit()
        {
            IsMouseOver = false;
        }
        #endregion
    }
}
