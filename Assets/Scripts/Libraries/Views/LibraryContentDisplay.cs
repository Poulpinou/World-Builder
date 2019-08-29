using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGTools.UI;

namespace WorldBuilder.Libraries
{
	public class LibraryContentDisplay : UIGrid
	{
        #region Public Variables
        [SerializeField] Library library;
        #endregion

        #region Properties
        public Library Library {
            get => library;
            set {
                library = value;
                Clear();
                AddItems(library.GetRawItems());
            }
        }
        #endregion

        #region Private Methods
        protected override void Build()
        {
            base.Build();

            if(library != null)
                AddItems(library.GetRawItems());
        }
        #endregion
    }
}
