using Internal.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

namespace Internal.MonsterPartSystem.MoveSetSchemes
{
    [Serializable]
    public class GridCell
    {
        public bool isMarked = false;
    }

    public abstract class SchemeBase_SO : ScriptableObject
    {
        public const int WIDTH = 5;
        public const int HEIGHT = 5;

        [HideInInspector]
        public GridCell[] Grid;

        [HideInInspector]
        public Vector2Int MonsterPosition;


        private void OnEnable()
        {
            if (Grid == null)
            {
                InitializeGrid();
            }
        }

        private void OnValidate()
        {
            if (Grid.Length != WIDTH * HEIGHT)
            {
                InitializeGrid();
            }
        }

        public void InitializeGrid()
        {
            Grid = new GridCell[WIDTH * HEIGHT];

            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    Grid[x + y * WIDTH] = new GridCell();
                }
            }

            MonsterPosition = new Vector2Int((WIDTH - 1) / 2, (WIDTH - 1) / 2);
        }


        public GridCell GetCell(int x,  int y)
        {
            if (x < 0 || x >= WIDTH || y < 0 || y >= HEIGHT)
                throw new System.IndexOutOfRangeException("Coordinates are out of bounds");
            return Grid[y * WIDTH + x];
        }
        public List<Vector2Int> MapToVector2s()
        {
            List<Vector2Int> result = new();

            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    if(Grid[x + y * WIDTH].isMarked)
                    {
                        var mapped_value = new Vector2Int(x, y) - MonsterPosition;
                        result.Add(mapped_value);
                    }
                }
            }

            return result;
        }
    }
}
