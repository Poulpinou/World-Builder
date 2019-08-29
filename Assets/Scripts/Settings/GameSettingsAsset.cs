using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder.Settings
{
    [CreateAssetMenu(menuName = "WorldBuilder/GameSettings")]
	public class GameSettingsAsset : ScriptableObject
	{
        [Header("Materials")]
        public Material validMaterial;
        public Material invalidMaterial;
        public Material ghostedMaterial;
    }
}
