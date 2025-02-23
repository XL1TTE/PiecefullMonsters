using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.UI
{
    [RequireComponent(typeof(MapClient))]
    public class UIMapper : MonoBehaviour
    {
        private MapClient MapClient;

        [SerializeField]
        private RectTransform LayoutsScrollRect;

        [SerializeField]
        private Vector3 HorizontalPageStep;
        [SerializeField]
        private Vector3 VerticalPageStep;

        [SerializeField]
        private float TweenTime;

        [SerializeField]
        private LeanTweenType TweenType;

        private Vector3 TargetPosition;


        [Header("Buttons refs.")]
        #region ButtonsRefs
        public Button LEFT_BTN;
        public Button RIGHT_BTN;
        public Button UP_BTN;
        public Button DOWN_BTN;
        #endregion

        private void Awake()
        {
            MapClient = GetComponent<MapClient>();

            if (MapClient != null)
            {
                MapClient.OnCurrentPositionChanged += UpdateButtonsStateFromCurrentPosition;
            }

            TargetPosition = LayoutsScrollRect.localPosition;

        }

        public void MoveToDirection(Vector2Int direction)
        {
            if (MapClient.isDirectionAllowed(direction))
                MapClient.UpdateCurrentPosition(direction);

            if (direction == Vector2Int.left)
            {
                TargetPosition += HorizontalPageStep;
            }
            else if (direction == Vector2Int.right)
            {
                TargetPosition -= HorizontalPageStep;
            }
            else if (direction == Vector2Int.up)
            {
                TargetPosition -= VerticalPageStep;
            }
            else if (direction == Vector2Int.down)
            {
                TargetPosition += VerticalPageStep;
            }

            MoveToTarget();
        }

        private void MoveToTarget()
        {
            LayoutsScrollRect.LeanMoveLocal(TargetPosition, TweenTime).setEase(TweenType);
        }

        private void UpdateButtonsStateFromCurrentPosition()
        {
            LEFT_BTN.interactable = MapClient.isDirectionAllowed(Vector2Int.left);
            RIGHT_BTN.interactable = MapClient.isDirectionAllowed(Vector2Int.right);
            UP_BTN.interactable = MapClient.isDirectionAllowed(Vector2Int.up);
            DOWN_BTN.interactable = MapClient.isDirectionAllowed(Vector2Int.down);

        }


        #region ButtonsClickHandlers
        public void OnLeftButtonClick()
        {
            MoveToDirection(Vector2Int.left);
        }

        public void OnRightButtonClick()
        {
            MoveToDirection(Vector2Int.right);
        }

        public void OnUpButtonClick()
        {
            MoveToDirection(Vector2Int.up);
        }

        public void OnDownButtonClick()
        {
            MoveToDirection(Vector2Int.down);
        }
        #endregion
    }
}
