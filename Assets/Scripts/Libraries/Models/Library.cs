using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using WorldBuilder.Behaviours;
using UnityEditor;

namespace WorldBuilder.Libraries
{
    [CreateAssetMenu(menuName = "WorldBuilder/Libraries/Library")]
    [Serializable]
    public class Library : ScriptableObject, IEnumerable, IEnumerable<WorldObject> {
        #region Public Variables
        [Readonly] [SerializeField] string libraryID;
        [SerializeField] List<LibraryLink> items = new List<LibraryLink>();
        #endregion

        #region Properties
        public IEnumerable<WorldObject> Items => items.Select(l => l.Item);
        public string LibraryID => libraryID;
        #endregion

        #region Public Methods
        public WorldObject GetItemWithID(string itemID)
        {
            LibraryLink result = items.Where(i => i.ItemID == itemID).FirstOrDefault();
            if (result.Equals(null)) return null;
            return result.Item;
        }

        public void AddItem(WorldObject item, bool force = false)
        {
            CheckLock();
            if (Items.Contains(item))
                throw new Exception(string.Format("{0} already contains {1}", name, item.gameObject.name));

            LibraryLinkBehaviour linkBehaviour = item.GetBehaviour<LibraryLinkBehaviour>();
            LibraryLink link = new LibraryLink(this, item);

            if (linkBehaviour != null)
            {
                if (!linkBehaviour.IsValid || force)
                {                    
                    linkBehaviour.Library.RemoveItem(item);
                    linkBehaviour.Link = link;
                }
                else
                {
                    throw new Exception(string.Format("{0} already exist in {1}", item.gameObject.name, linkBehaviour.Library.name));                   
                }
            }
            else {
                item.AttachBehaviour<LibraryLinkBehaviour, LibraryLink>(link, this);
            }

            items.Add(link);
            SetDirty();
            AssetDatabase.SaveAssets();
        }

        public void RemoveItem(WorldObject item)
        {
            CheckLock();
            if (Items.Contains(item))
            {
                items.Remove(items.Where(l => l.Item == item).First());
                SetDirty();
                AssetDatabase.SaveAssets();
            }  
        }

        public IEnumerator GetEnumerator()
        {
            return items.GroupBy(i => i.Item).GetEnumerator();
        }

        IEnumerator<WorldObject> IEnumerable<WorldObject>.GetEnumerator()
        {
            return items.GroupBy(i => i.Item).Cast<WorldObject>().GetEnumerator();
        }
        #endregion

        #region Private Methods
        void CheckLock()
        {
            if (Application.isPlaying)
                throw new Exception("Library cannot be modified at runtime");
        }
        #endregion

        #region Runtime Methods
        private void OnEnable()
        {
            if (string.IsNullOrEmpty(libraryID))
            {
                libraryID = Guid.NewGuid().ToString("N");
                Debug.Log(string.Format("ID generated for {0} : {1}", name, libraryID));
            }
        }
        #endregion
        
    }
}
