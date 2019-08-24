using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGTools;
using System.Linq;
using System;

namespace WorldBuilder.World
{
    public class SelectionManager : StaticManager<SelectionManager>
    {
        #region Enums
        public enum SelectionMode { single, many, none }
        #endregion

        #region PrivateVariables
        SelectionMode selectionMode = SelectionMode.single;

        List<WorldObject> selected = new List<WorldObject>();

        Type typeRestriction = null;
        #endregion

        #region Properties
        /// <summary>
        /// Get or Set the current <see cref="SelectionMode"/>, this will affect the current selection 
        /// </summary>
        public SelectionMode CurrentSelectionMode {
            get => selectionMode;
            set {
                ChangeSelectionMode(value);
            }
        }

        /// <summary>
        /// Get or Set the Type restriction, if a restriction has been set, the selection won't allow items that doesn't fetch that Type
        /// </summary>
        public Type TypeRestriction {
            get => typeRestriction;
            set {
                typeRestriction = value;
                List<WorldObject> toKeep = new List<WorldObject>();
                foreach (WorldObject item in selected) {
                    if (item.GetComponent(typeRestriction) != null) {
                        toKeep.Add(item);
                    }
                    selected = toKeep;
                }
            }
        }

        /// <summary>
        /// True if a <see cref="TypeRestriction"/> has been set
        /// </summary>
        public bool HasTypeRestriction => typeRestriction != null;

        /// <summary>
        /// Returns the active selection (returns the first selected if in <see cref="SelectionMode.many"/>)
        /// </summary>
        public WorldObject Selected
        {
            get {
                switch (selectionMode)
                {
                    case SelectionMode.single:
                    case SelectionMode.many:
                        return selected.FirstOrDefault();
                    case SelectionMode.none:
                        throw new Exception(string.Format("Impossible to get selection this way in {0} SelectionMode", selectionMode));
                }
                return null;
            }
        }

        /// <summary>
        /// Returns every selected items in <see cref="SelectionMode.many"/>
        /// </summary>
        public List<WorldObject> ManySelected
        {
            get
            {
                switch (selectionMode)
                {
                    case SelectionMode.many:
                        return selected;
                    case SelectionMode.single:
                    case SelectionMode.none:
                        throw new Exception(string.Format("Impossible to get selection this way in {0} SelectionMode", selectionMode));
                }
                return null;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Changes the active <see cref="SelectionMode"/> (does the same thing as <see cref="CurrentSelectionMode"/> setter)
        /// </summary>
        /// <param name="target"></param>
        public void ChangeSelectionMode(SelectionMode target) {
            switch (target)
            {
                case SelectionMode.single:
                    selected = new List<WorldObject>() {Selected};
                    break;
                case SelectionMode.many:
                    break;
                case SelectionMode.none:
                    selected = null;
                    break;
            }
            selectionMode = target;
        }

        /// <summary>
        /// Remove every item from the selection
        /// </summary>
        public void ClearSelection() {
            selected = new List<WorldObject>();
        }

        /// <summary>
        /// Select one or many items (this will clear the previous selection)
        /// </summary>
        /// <param name="selection">Items to add to the selection</param>
        public void Select(params WorldObject[] selection) {
            if (IsValidSelection(selection)) {
                ClearSelection();
                selected.AddRange(selection);
            }
        }

        /// <summary>
        /// Select one or many items (this won't clear the previous selection)
        /// </summary>
        /// <param name="selection">Items to add to the selection</param>
        public void AddToSelection(params WorldObject[] selection) {
            if (IsValidSelection(selection)) {
                selected.AddRange(selected);
            }
        }

        /// <summary>
        /// Remove one or many items from the current selection
        /// </summary>
        /// <param name="selection">Items to add to the selection</param>
        public void RemoveFromSelection(params WorldObject[] selection) {
            foreach (WorldObject worldObject in selection) {
                if (selected.Contains(worldObject))
                    selected.Remove(worldObject);
            }
        }

        /// <summary>
        /// Tries to Select one or many items (this will clear the previous selection)
        /// </summary>
        /// <param name="selection">Items to add to the selection</param>
        /// <returns>Returns false if failed to Select</returns>
        public bool TrySelect(params WorldObject[] selection) {
            try
            {
                Select(selection);
            }
            catch {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Tries to Select one or many items (this won't clear the previous selection)
        /// </summary>
        /// <param name="selection">Items to add to the selection</param>
        /// <returns>Returns false if failed to Select</returns>
        public bool TryAddToSelection(params WorldObject[] selection)
        {
            try
            {
                AddToSelection(selection);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns selected items as <typeparamref name="TItem"/> (throws cast errors)
        /// </summary>
        /// <typeparam name="TItem">This type should inherit from <see cref="WorldObject"/></typeparam>
        public List<TItem> GetSelectedAs<TItem>() where TItem : WorldObject {
            return selected as List<TItem>;
        }

        /// <summary>
        /// Returns selected items that has the type <typeparamref name="TItem"/> (doesn't throw cast errors, but doesn't return invalid items)
        /// </summary>
        /// <typeparam name="TItem">This type should inherit from <see cref="WorldObject"/></typeparam>
        public List<TItem> GetSelectedOfType<TItem>() where TItem : WorldObject {
            return selected.Where(i => i is TItem) as List<TItem>;
        }
        #endregion

        #region Private Methods
        public bool IsValidSelection(params WorldObject[] selection) {
            if (selectionMode == SelectionMode.none)
            {
                throw new Exception(string.Format("Impossible to select in {0} SelectionMode", selectionMode));
            }

            if(selectionMode == SelectionMode.single && selection.Length > 1)
            {
                throw new Exception(string.Format("Impossible to select many in {0} SelectionMode", selectionMode));
            }

            if (!HasTypeRestriction) return true;
            foreach (WorldObject worldObject in selection) {
                if (worldObject.GetComponent(typeRestriction) == null) {
                    throw new Exception(string.Format("Selection doesn't match type restriction : {0}", typeRestriction));
                }
            }
            return true;
        }
        #endregion
    }
}
