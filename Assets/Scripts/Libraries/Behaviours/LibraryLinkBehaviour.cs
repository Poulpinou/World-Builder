using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldBuilder.Behaviours;

namespace WorldBuilder.Libraries
{
    public class LibraryLinkBehaviour : Behaviour<LibraryLink>
    {
        public bool IsValid {
            get{
                return Item != null 
                    && Library != null 
                    && Library.GetItemWithID(ItemID) != null;
            }
        }

        public LibraryLink Link
        {
            get => inputParams;
            set => inputParams = value;
        }

        public Library Library => Link.Library;
        public string LibraryID => Link.Library.LibraryID;
        public WorldObject Item => Link.Item;
        public string ItemID => Link.ItemID;

        protected override void Enter()
        {
            
        }

        protected override void Exit()
        {
            
        }

        
    }
}
