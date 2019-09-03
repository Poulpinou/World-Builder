using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WorldBuilder.Blueprints
{
	public class FloorSelector : MonoBehaviour
	{
        [SerializeField] Button moreButton;
        [SerializeField] Button lessButton;
        [SerializeField] Text valueText;

        BlueprintGrid grid;

        void IncrementFloor() {
            if (grid.CurrentFloor + 1 >= grid.Datas.Floors.Count)
            {
                grid.Datas.AddFloor();
            }
            else {
                grid.ChangeFloor(grid.CurrentFloor + 1);
            }

            valueText.text = grid.CurrentFloor.ToString();
        }

        void DecrementFloor() {
            if (grid.CurrentFloor - 1 < 0) return;
            grid.ChangeFloor(grid.CurrentFloor - 1);

            valueText.text = grid.CurrentFloor.ToString();
        }

        private void Start()
        {
            grid = BlueprintEditor.active.grid;
            moreButton.onClick.AddListener(IncrementFloor);
            lessButton.onClick.AddListener(DecrementFloor);

            valueText.text = grid.CurrentFloor.ToString();
        }
    }
}
