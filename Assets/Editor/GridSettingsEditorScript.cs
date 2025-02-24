using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;
namespace Internal
{
    [CustomEditor(typeof(Grid_ABS), true)]
    public class NewBehaviourScript : Editor
    {
        public override void OnInspectorGUI()
        {
            Grid_ABS _grid = (Grid_ABS)target;

            _grid.Height = EditorGUILayout.IntField("Height", _grid.Height);
            _grid.Width = EditorGUILayout.IntField("Width", _grid.Width);
            EditorGUILayout.LabelField("Grid");
            if (_grid.Cells == null || _grid.Cells.Count != _grid.Height * _grid.Width)
            {
                _grid.Cells = new List<bool>(new bool[_grid.Height *_grid.Width]);
            }
            for (int i = 0; i < _grid.Height; i++)
            {
                EditorGUILayout.BeginHorizontal();
                for (int j = 0; j < _grid.Width; j++)
                {
                    int index = i * _grid.Width + j;
                    _grid.Cells[index] = EditorGUILayout.Toggle(_grid.Cells[index], GUILayout.Width(20));
                }
                EditorGUILayout.EndHorizontal();
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(_grid);
            }
            DrawDefaultInspector();
        }
        
    }
}
