using Internal.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.UI
{

    public class MapClient : MonoBehaviour
    {

        #region PreConf_Fields

        [SerializeField] public Vector2Int StartPosition;
        [SerializeField] public MapScheme MapScheme;

        [HideInInspector] private Vector2Int CurrentPosition;
        [HideInInspector] public event Action OnCurrentPositionChanged;

        #endregion

        private void Awake()
        {
            CurrentPosition = StartPosition;
        }

        private void Start()
        {
            CurrentPositionChanged();
        }


        public bool IsCellMarked(int x, int y)
        {
            try
            {
                bool isMarked = MapScheme.GetCell(x, y).isMarked;
                return isMarked;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateCurrentPosition(Vector2Int direction)
        {
            CurrentPosition += direction;
            CurrentPositionChanged();
        }

        public bool isDirectionAllowed(Vector2Int direction)
        {
            var to_check = direction + CurrentPosition;

            try
            {
                return this.IsCellMarked(to_check.x, to_check.y);
            }
            catch
            {
                return false;
            }
        }


        private void CurrentPositionChanged()
        {
            OnCurrentPositionChanged.Invoke();
        }
    }
}
