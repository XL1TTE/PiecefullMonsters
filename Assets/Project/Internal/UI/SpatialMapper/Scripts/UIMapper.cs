using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Internal.LaboratoryUI.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.UI
{
    [Serializable]
    public class UIMapper
    {

        [SerializeField]
        private RectTransform LayoutsScrollRect;

        [SerializeField]
        private Vector3 HorizontalPageStep;
        [SerializeField]
        private Vector3 VerticalPageStep;

        [SerializeField]
        private float TweenTime;

        [SerializeField]
        private Ease TweenType;

        private Vector3 TargetPosition;

        [HideInInspector] public SectionControllerBase PrevSectionController;
        [HideInInspector] public SectionControllerBase CurrentSectionController;

        public event Action CurrentSectionControllerChanged;
        public void OnCurrentSectionChanged()
        {
            CurrentSectionControllerChanged?.Invoke();
        }

        public IEnumerator Init(SectionControllerBase StartSection)
        {

            TargetPosition = LayoutsScrollRect.localPosition;

            if (StartSection != null)
            {
                CurrentSectionController = StartSection;
            }
            else
            {
                Debug.LogError("Start section controller was not specified in UIMapper");
            }

            yield return null;

        }

        public void MoveToSectionInDirection(Vector2Int direction, SectionControllerBase section_controller)
        {
            if (direction == Vector2Int.left)
            {
                TargetPosition += HorizontalPageStep;
                ChangeActiveSection(section_controller);

            }
            else if (direction == Vector2Int.right)
            {
                TargetPosition -= HorizontalPageStep;
                ChangeActiveSection(section_controller);
            }
            else if (direction == Vector2Int.up)
            {
                TargetPosition -= VerticalPageStep;
                ChangeActiveSection(section_controller);
            }
            else if (direction == Vector2Int.down)
            {
                TargetPosition += VerticalPageStep;
                ChangeActiveSection(section_controller);
            }
            MoveToTarget();
        }

        private void ChangeActiveSection(SectionControllerBase section_controller)
        {
            PrevSectionController = CurrentSectionController;
            CurrentSectionController = section_controller;
            OnCurrentSectionChanged();
        }
        private void MoveToTarget()
        {
            LayoutsScrollRect.DOLocalMove(TargetPosition, TweenTime).SetEase(TweenType);
        }
    }
}
