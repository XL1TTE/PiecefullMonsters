using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Internal.UI.Editor
{
    [CustomEditor(typeof(MapScheme))]
    public class MapScheme_Editor : UnityEditor.Editor
    {
        private MapScheme _mapScheme;

        private bool _showGrid;

        private void OnEnable()
        {
            _mapScheme = (MapScheme)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (_mapScheme == null || _mapScheme.cells == null) return;


            if (_mapScheme.width <= 0 || _mapScheme.height <= 0)
            {
                EditorGUILayout.LabelField("Invalid grid size: make sure that width and height both are greater then 0.");
                return;
            }
            _showGrid = EditorGUILayout.Foldout(_showGrid, "Map Grid", true, EditorStyles.foldoutHeader);

            if (_showGrid)
            {
                if (_mapScheme.width <= 0 || _mapScheme.height <= 0)
                {
                    EditorGUILayout.LabelField("Invalid grid size: make sure that width and height both are greater than 0.");
                    return;
                }

                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginVertical();

                for (int y = _mapScheme.height - 1; y >= 0; y--)
                {
                    EditorGUILayout.BeginHorizontal();
                    for (int x = 0; x < _mapScheme.width; x++)
                    {
                        MapCell cell = _mapScheme.GetCell(x, y);
                        cell.isMarked = GUILayout.Toggle(cell.isMarked, GUIContent.none, GUILayout.Width(20), GUILayout.Height(20));
                    }
                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }
            if (GUILayout.Button("Save Changes"))
            {
                EditorUtility.SetDirty(_mapScheme);
            }
        }
    }
}
