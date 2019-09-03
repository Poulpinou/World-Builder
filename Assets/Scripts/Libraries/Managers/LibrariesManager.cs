using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGTools;
using System.Linq;

namespace WorldBuilder.Libraries
{
	public class LibrariesManager : StaticManager<LibrariesManager>
	{
        #region Public Variables
        [Header("Path Settings")]
        [FolderPath(folderPathRestriction = "Resources")] public string folderPath = "";
        #endregion

        #region Private Variables
        Library[] libraries;
        #endregion

        #region Properties
        public static Library[] Libraries => active.libraries;
        #endregion

        #region Public Methods
        public static IEnumerable<TItem> Query<TItem>(bool strictTypeMatch = false) where TItem : WorldObject
        {
            return Libraries.SelectMany(l => l.Items).Cast<TItem>();
        }

        public static IEnumerable<WorldObject> QueryAll()
        {
            return Libraries.SelectMany(l => l.Items);
        }

        public static Library GetLibraryFromID(string libraryID)
        {
            return Libraries.Where(l => l.LibraryID == libraryID).FirstOrDefault();
        }

        public static WorldObject GetItemFromID(string fullLibraryID)
        {
            LibraryLink link = new LibraryLink(fullLibraryID);
            return link.Item;
        }
        #endregion

        #region Runtime MEthods
        protected override void Awake()
        {
            base.Awake();
            libraries = Resources.LoadAll<Library>(active.folderPath);
        }
        #endregion

        #region Editor Methods
        public static void ForceEditorRef()
        {
            FindObjectOfType<LibrariesManager>().Awake();
        }
        #endregion
    }
}
