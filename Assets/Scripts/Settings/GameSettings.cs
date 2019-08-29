using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGTools;
using WorldBuilder.Settings;

namespace WorldBuilder
{
	public class GameSettings : StaticManager<GameSettings>
	{
        [SerializeField] GameSettingsAsset settingsAsset;

        public static GameSettingsAsset Settings => active.settingsAsset;
	}
}
