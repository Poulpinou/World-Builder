using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace WorldBuilder.Libraries
{
    [Serializable]
	public struct LibraryLink
	{
        [SerializeField] [Readonly] Library library;
        [SerializeField] [Readonly] WorldObject item;
        [SerializeField] [Readonly] string itemID;

        public Library Library => library;
        public string LibraryID => library.LibraryID;
        public WorldObject Item => item;
        public string ItemID => itemID;

        public LibraryLink(Library library, WorldObject item)
        {
            this.library = library;
            this.item = item;
            this.itemID = Guid.NewGuid().ToString("N");
        }

        public LibraryLink(string libID)
        {
            string[] split = libID.Split('_');
            if (split.Length != 3 && split[0] != "libID")
            {
                throw new Exception("Invalid library ID!");
            }

            library = LibrariesManager.GetLibraryFromID(split[1]);           
            itemID = split[2];
            item = library.GetItemWithID(itemID);
        }

        public override string ToString()
        {
            return string.Format("libID_{0}_{1}", LibraryID, ItemID);
        }
    }
}
