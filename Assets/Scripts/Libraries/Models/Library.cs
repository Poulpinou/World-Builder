using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace WorldBuilder.Libraries
{
    public abstract class Library : ScriptableObject {
        public abstract WorldObject[] GetRawItems();
    }

	public abstract class Library<TItem> : Library where TItem : WorldObject
	{
        [SerializeField] protected TItem[] items;

        public TItem[] Items => items;

        public override WorldObject[] GetRawItems()
        {
            return Items;
        }
    }
}
