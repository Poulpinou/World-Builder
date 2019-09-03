using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;

namespace WorldBuilder.Libraries.Editor
{
    [CustomEditor(typeof(Library), true)]
	public class LibraryDrawer : UnityEditor.Editor
	{
        string message;
        Vector2 itemsSroll = Vector2.zero;

        public override void OnInspectorGUI()
        {
            if(LibrariesManager.active == null)
            {
                LibrariesManager.ForceEditorRef();
            }

            if(LibrariesManager.active == null)
            {
                GUILayout.BeginVertical(EditorStyles.helpBox);

                GUILayout.Label("Current Scene should have a LibraryManager object to edit Library");

                GUILayout.EndVertical();

                return;
            }

            Library library = (Library)target;

            if(!string.IsNullOrEmpty(message))
                GUILayout.Label(message);

            #region Add Item Box
            GUILayout.Label("Actions", EditorStyles.boldLabel);

            GUILayout.BeginVertical(EditorStyles.helpBox);

            GUILayout.Label("Put here the item you want to add to the library");
            WorldObject obj = null;
            obj = EditorGUILayout.ObjectField(obj, typeof(WorldObject), false) as WorldObject;

            if(obj != null)
            {
                try
                {
                    library.AddItem(obj);
                }
                catch (Exception e)
                {
                    message = e.Message;
                    Debug.Log(e.StackTrace);
                }
            }

            GUILayout.EndVertical();
            #endregion

            #region Display List Box
            GUILayout.Label("Items", EditorStyles.boldLabel);

            itemsSroll = GUILayout.BeginScrollView(itemsSroll, EditorStyles.helpBox);

            WorldObject[] items = library.Items.ToArray();

            for (int i = 0; i < items.Length; i++)
            {
                if (items[0] != null) {
                    GUILayout.BeginVertical(EditorStyles.helpBox);

                    GUILayout.BeginHorizontal(EditorStyles.toolbar);
                    GUILayout.Label(items[i].CustomName, EditorStyles.boldLabel);
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("x", GUILayout.Width(30)))
                    {
                        library.RemoveItem(items[i]);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    GUILayout.Label(items[i].Icon, GUILayout.MaxHeight(100), GUILayout.MaxWidth(100));

                    GUILayout.Label(items[i].Description, EditorStyles.boldLabel);

                    GUILayout.EndHorizontal();

                    GUILayout.EndVertical();
                }
            }
            #endregion


            GUILayout.EndScrollView();
        }
    }
}
