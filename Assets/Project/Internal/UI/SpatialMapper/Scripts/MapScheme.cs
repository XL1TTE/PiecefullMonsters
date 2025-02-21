using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.UI
{
    [CreateAssetMenu(fileName = "MapScheme_SO", menuName = "UI/SpatialMapper")]
    public class MapScheme : ScriptableObject
    {
        #region Fields

        [Header("Map grid size:")]
        public int width = 5;
        public int height = 5;

        [HideInInspector]
        public MapCell[] cells;

        #endregion


        private void OnEnable()
        {
            if (cells == null)
            {
                InitializeMap();
            }
        }

        // Initialize Map of specified size with empty MapCells objects...
        private void InitializeMap()
        {
            if (width <= 0 || height <= 0) return;

            cells = new MapCell[width * height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x + y * width] = new MapCell { isMarked = false };
                }
            }
        }

        /// <summary>
        /// Return the instance of MapCell with (x, y) position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>MapCell object</returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public MapCell GetCell(int x, int y)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
                throw new System.IndexOutOfRangeException("Coordinates are out of bounds");
            return cells[y * width + x];
        }
    }
}


