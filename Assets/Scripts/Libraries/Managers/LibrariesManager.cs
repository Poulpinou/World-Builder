using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGTools;
using System.IO;
using System.Linq;

namespace WorldBuilder.Libraries
{
	public class LibrariesManager : StaticManager<LibrariesManager>
	{
        #region Public Variables
        [Header("Path Settings")]
        [FolderPath(folderPathRestriction = "Resources")] public string folderPath = "";
        #endregion

        #region Public Methods
        public static TLibrary[] GetLibraries<TLibrary>() where TLibrary : Library
        {
            return Resources.LoadAll<TLibrary>(GetLibrariesPath<TLibrary>());
        }

        public static TLibrary GetLibrary<TLibrary>(string name) where TLibrary : Library
        {
            string path = GetLibraryPath<TLibrary>(name);
            TLibrary library = Resources.Load<TLibrary>(path);

            if (library == null) {
                throw new FileNotFoundException(string.Format("No library file found at {0}", path));
            }

            return library;
        }

        public static string GetLibrariesPath<TLibrary>() where TLibrary : Library
        {
            return Path.Combine(active.folderPath, typeof(TLibrary).Name);
        }

        public static string GetLibraryPath<TLibrary>(string libraryName) where TLibrary : Library
        {
            return Path.Combine(GetLibrariesPath<TLibrary>(), libraryName);
        }

        public static IEnumerable<TItem> Query<TLibrary, TItem>(string name) where TLibrary : Library<TItem> where TItem : WorldObject {
            return GetLibrary<TLibrary>(name).Items;
        }

        public static IEnumerable<TItem> QueryAll<TLibrary, TItem>() where TLibrary : Library<TItem> where TItem : WorldObject
        {
            return GetLibraries<TLibrary>().SelectMany(l => l.Items);
        }
        #endregion
    }
}
