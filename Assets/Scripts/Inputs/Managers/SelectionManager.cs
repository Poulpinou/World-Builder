using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGTools;
using System.Linq;
using System;

namespace WorldBuilder.Inputs
{
    /// <summary>
    /// This class manages the selection of <see cref="WorldObject"/>
    /// </summary>
    public class SelectionManager : StaticManager<SelectionManager>
    {
        #region Enums
        public enum SelectionMode { single, many, none }
        #endregion

        #region Private Variables
        SelectionMode selectionMode = SelectionMode.single;

        List<WorldObject> selected = new List<WorldObject>();

        Type typeRestriction = null;
        #endregion

        #region Events
        public static WorldObjectListEvent onSelectionChanged = new WorldObjectListEvent();
        #endregion

        #region Properties
        /// <summary>
        /// Get or Set the current <see cref="SelectionMode"/>, this will affect the current selection 
        /// </summary>
        public static SelectionMode CurrentSelectionMode {
            get => active.selectionMode;
            set {
                ChangeSelectionMode(value);
            }
        }

        /// <summary>
        /// Get or Set the Type restriction, if a restriction has been set, the selection won't allow items that doesn't fetch that Type
        /// </summary>
        public static Type TypeRestriction {
            get => active.typeRestriction;
            set {
                active.typeRestriction = value;
                List<WorldObject> toKeep = new List<WorldObject>();
                foreach (WorldObject item in active.selected) {                   
                    if (item != null && item.GetComponent(active.typeRestriction) != null) {
                        toKeep.Add(item);
                    }
                }
                active.selected = toKeep;
            }
        }

        /// <summary>
        /// True if a <see cref="TypeRestriction"/> has been set
        /// </summary>
        public static bool HasTypeRestriction => TypeRestriction != null;

        /// <summary>
        /// Returns the active selection (returns the first selected if in <see cref="SelectionMode.many"/>)
        /// </summary>
        public static WorldObject Selected
        {
            get {
                switch (CurrentSelectionMode)
                {
                    case SelectionMode.single:
                    case SelectionMode.many:
                        return active.selected.FirstOrDefault();
                    case SelectionMode.none:
                        throw new Exception(string.Format("Impossible to get selection this way in {0} SelectionMode", CurrentSelectionMode));
                }
                return null;
            }
        }

        /// <summary>
        /// Returns every selected items in <see cref="SelectionMode.many"/>
        /// </summary>
        public static List<WorldObject> ManySelected
        {
            get
            {
                switch (CurrentSelectionMode)
                {
                    case SelectionMode.many:
                        return active.selected;
                    case SelectionMode.single:
                    case SelectionMode.none:
                        throw new Exception(string.Format("Impossible to get selection this way in {0} SelectionMode", CurrentSelectionMode));
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
        public static void ChangeSelectionMode(SelectionMode target) {
            switch (target)
            {
                case SelectionMode.single:
                    active.selected = new List<WorldObject>() {Selected};
                    break;
                case SelectionMode.many:
                    break;
                case SelectionMode.none:
                    active.selected = null;
                    break;
            }
            active.selectionMode = target;
        }

        /// <summary>
        /// Remove every item from the selection
        /// </summary>
        public static void ClearSelection() {
            active.selected = new List<WorldObject>();
            onSelectionChanged.Invoke(active.selected);
        }

        /// <summary>
        /// Select one or many items (this will clear the previous selection)
        /// </summary>
        /// <param name="selection">Items to add to the selection</param>
        public static void Select(params WorldObject[] selection) {
            if (active.IsValidSelection(selection)) {
                ClearSelection();
                active.selected.AddRange(selection);
                onSelectionChanged.Invoke(active.selected);
            }
        }

        /// <summary>
        /// Select one or many items (this won't clear the previous selection)
        /// </summary>
        /// <param name="selection">Items to add to the selection</param>
        public static void AddToSelection(params WorldObject[] selection) {
            if (active.IsValidSelection(selection)) {
                active.selected.AddRange(selection);
                onSelectionChanged.Invoke(active.selected);
            }
        }

        /// <summary>
        /// Remove one or many items from the current selection
        /// </summary>
        /// <param name="selection">Items to add to the selection</param>
        public static void RemoveFromSelection(params WorldObject[] selection) {
            foreach (WorldObject worldObject in selection) {
                if (active.selected.Contains(worldObject))
                    active.selected.Remove(worldObject);                
            }
            onSelectionChanged.Invoke(active.selected);
        }

        /// <summary>
        /// Tries to Select one or many items (this will clear the previous selection)
        /// </summary>
        /// <param name="selection">Items to add to the selection</param>
        /// <returns>Returns false if failed to Select</returns>
        public static bool TrySelect(params WorldObject[] selection) {
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
        public static bool TryAddToSelection(params WorldObject[] selection)
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
        public static List<TItem> GetSelectedAs<TItem>() where TItem : WorldObject {
            return active.selected as List<TItem>;
        }

        /// <summary>
        /// Returns selected items that has the type <typeparamref name="TItem"/> (doesn't throw cast errors, but doesn't return invalid items)
        /// </summary>
        /// <typeparam name="TItem">This type should inherit from <see cref="WorldObject"/></typeparam>
        public static List<TItem> GetSelectedOfType<TItem>() where TItem : WorldObject {
            return active.selected.Where(i => i is TItem) as List<TItem>;
        }

        /// <summary>
        /// Return true if every <paramref name="selection"/> are selected
        /// </summary>
        /// <param name="selection">Items to check</param>
        public static bool Contains(params WorldObject[] selection) {
            foreach (WorldObject worldObject in selection)
            {
                if (!active.selected.Contains(worldObject))
                    return false;
            }
            return true;
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
