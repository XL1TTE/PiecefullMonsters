
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Internal.MonsterPartSystem.MoveSetSchemes.Editor
{
    [CustomEditor(typeof(SchemeBase_SO))]
    public class Scheme_SO_Editor : UnityEditor.Editor
    {

        private SchemeBase_SO _scheme;

        private bool _showGrid = false;
        private Texture2D _monsterPositionSprite;

        private void Awake()
        {
            _monsterPositionSprite = Resources.Load<Texture2D>("monster_icon2");
        }

        private void OnEnable()
        {
            _scheme = (SchemeBase_SO)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (_scheme == null || _scheme.Grid == null) return;


            _showGrid = EditorGUILayout.Foldout(_showGrid, "Map Grid", true, EditorStyles.foldoutHeader);

            if (_showGrid)
            {

                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginVertical();

                for (int y = SchemeBase_SO.WIDTH-1; y >= 0; y--)
                {
                    EditorGUILayout.BeginHorizontal();
                    for (int x = 0; x < SchemeBase_SO.WIDTH; x++)
                    {

                        if (_scheme.MonsterPosition.x == x && _scheme.MonsterPosition.y == y)
                        {
                            GUILayout.Toggle(true, GUIContent.none, GUILayout.Width(20), GUILayout.Height(20));
                        }
                        else {

                            GridCell cell = _scheme.GetCell(x, y);
                            cell.isMarked = GUILayout.Toggle(cell.isMarked, GUIContent.none, GUILayout.Width(20), GUILayout.Height(20));
                        }

                    }
                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }
        }
    }

    [CustomEditor(typeof(AttackScheme_SO))]
    public class AttackScheme_SO_Editor: Scheme_SO_Editor
    {

    }

    [CustomEditor(typeof(MoveScheme_SO))]
    public class MoveScheme_SO_Editor : Scheme_SO_Editor
    {

    }
}
