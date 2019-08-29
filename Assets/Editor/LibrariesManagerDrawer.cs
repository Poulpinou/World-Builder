using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using DGTools;

namespace WorldBuilder.Libraries.Editor
{
    [CustomEditor(typeof(LibrariesManager))]
    public class LibrariesManagerDrawer : UnityEditor.Editor
    {
        string message;

        public override void OnInspectorGUI()
        {
            LibrariesManager librariesManager = (LibrariesManager)target;

            DrawDefaultInspector();

            GUILayout.BeginVertical(EditorStyles.helpBox);

            if (string.IsNullOrEmpty(librariesManager.folderPath)) {
                EditorGUILayout.LabelField("Please set the folder path", EditorStyles.boldLabel);
            }
            else
            {
                EditorGUILayout.LabelField("Drop a library script down there to create a folder for it", EditorStyles.miniLabel);

                MonoScript script = null;
                script = EditorGUILayout.ObjectField(script, typeof(MonoScript), false) as MonoScript;

                if (script != null) {
                    try
                    {
                        CreateLibraryFolder(script.GetClass());
                    }
                    catch (Exception e) {
                        message = e.Message;
                    }
                    
                }

                if (!string.IsNullOrEmpty(message)) {
                    EditorGUILayout.LabelField(message);
                }
            }

            GUILayout.EndHorizontal();
        }

        void CreateLibraryFolder(Type libraryType) {
            LibrariesManager librariesManager = (LibrariesManager)target;

            if (!typeof(Library).IsAssignableFrom(libraryType)) {
                throw new Exception("Script should inherit from Library!");
            }

            if (libraryType.IsAbstract)
            {
                throw new Exception("Class can't be abstract!");
            }

            string path = Path.Combine(PathUtilities.absolutePath, "Resources", librariesManager.folderPath, libraryType.Name);

            if (Directory.Exists(path)) {
                throw new Exception(string.Format("A folder named {0} already exists!", libraryType.Name));
            }

            Directory.CreateDirectory(path);

            AssetDatabase.Refresh();

            message = string.Format("{0} folder successfully created!", libraryType.Name);
        }
    }
}
