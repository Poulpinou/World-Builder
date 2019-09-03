using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldBuilder.Behaviours;
using WorldBuilder.Inputs;
using WorldBuilder.Libraries;
using DGTools.UI;
using DGTools;

namespace WorldBuilder
{
    /// <summary>
    /// The main class for every scene objects
    /// </summary>
	public abstract class WorldObject : MonoBehaviour, ISelectable, IUITilable, IBehaviourable
	{
        #region Public Variables
        [Header("General infos")]
        [SerializeField] string displayedName;
        [SerializeField] string description;
        [SerializeField] Texture2D icon;
        #endregion

        #region Properties
        public virtual bool isSelected {
            get => SelectionManager.Contains(this);
            set => SelectionManager.AddToSelection(this);
        }

        public virtual string CustomName => string.IsNullOrEmpty(displayedName) ? name : displayedName;

        public virtual string Description => description;

        public virtual Texture2D Icon => icon;

        public virtual Color tileColor => Color.white;

        public virtual Sprite tileIcon => null;

        public virtual string tileTitle => CustomName;

        public virtual string tileText => Description;
        #endregion

        #region Public Methods
        public virtual void OnTileClick() { }
        #endregion
    }
}
