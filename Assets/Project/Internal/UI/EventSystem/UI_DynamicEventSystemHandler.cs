using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Internal.UI.EventSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Internal.UI.EventSystem
{
    public class UI_DynamicEventSystemHandler : MonoBehaviour
    {
        [Header("References")]
        public List<Selectable> Selectables = new List<Selectable>();
        [HideInInspector] protected Selectable _lastSelected;

        [Header("Controls")]

        [SerializeField] InputActionReference _navigateControlReference;

        [Header("Animations")]
        [SerializeField] protected float _selectedScaleMultiplyer = 1.1f;
        [SerializeField] protected float _selectedScaleDuration = 0.25f;

        [HideInInspector] protected Tween _scaleDownTween;
        [HideInInspector] protected Tween _scaleUpTween;


        protected Dictionary<Selectable, Vector3> _defaultscales = new Dictionary<Selectable, Vector3>();


        void OnEnable()
        {
            _navigateControlReference.action.performed += OnNavigate;
            for (int i = 0; i < Selectables.Count; i++)
            {
                Selectables[i].transform.localScale = _defaultscales[Selectables[i]];
            }
        }

        void OnDisable()
        {
            _navigateControlReference.action.performed -= OnNavigate;
            _scaleUpTween.Kill(true);
            _scaleDownTween.Kill(true);
        }


        protected IEnumerator SelectAfterDelay()
        {
            yield return null;
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(Selectables[0].gameObject);
        }

        public void AddSelectable(Selectable selectable)
        {
            Selectables.Add(selectable);
        }

        public void EnableBehaviour()
        {
            foreach (var sel in Selectables)
            {
                AddListeners(sel);
                _defaultscales.TryAdd(sel, sel.transform.localScale);
            }
            gameObject.SetActive(true);
        }

        public void DisableBehaviour()
        {
            foreach (var sel in Selectables)
            {
                RemoveListeners(sel);
            }
            gameObject.SetActive(false);
        }

        public IEnumerator SetFirstSelected()
        {
            yield return SelectAfterDelay();
        }

        protected virtual void AddListeners(Selectable selectable)
        {

            EventTrigger trigger = selectable.gameObject.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = selectable.gameObject.AddComponent<EventTrigger>();
            }

            EventTrigger.Entry PointerEnter = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerEnter
            };
            PointerEnter.callback.AddListener(OnPointerEnter);
            trigger.triggers.Add(PointerEnter);

            EventTrigger.Entry PointerExit = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerExit
            };
            PointerExit.callback.AddListener(OnPointerExit);
            trigger.triggers.Add(PointerExit);


            EventTrigger.Entry SelectEntry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.Select
            };
            SelectEntry.callback.AddListener(OnSelect);
            trigger.triggers.Add(SelectEntry);

            EventTrigger.Entry DeselectEntry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.Deselect
            };
            DeselectEntry.callback.AddListener(OnDeselect);
            trigger.triggers.Add(DeselectEntry);

        }

        protected virtual void RemoveListeners(Selectable selectable)
        {
            EventTrigger trigger = selectable.gameObject.GetComponent<EventTrigger>();
            if (trigger != null)
            {
                trigger.triggers.Clear();
            }
        }

        protected virtual void OnPointerExit(BaseEventData eventData)
        {
            PointerEventData pointerEventData = eventData as PointerEventData;
            if (pointerEventData != null)
            {
                pointerEventData.selectedObject = null;
            }
        }

        protected virtual void OnPointerEnter(BaseEventData eventData)
        {
            PointerEventData pointerEventData = eventData as PointerEventData;
            if (pointerEventData != null)
            {
                var selectable = pointerEventData.pointerEnter.GetComponentInParent<Selectable>();
                if (selectable == null)
                {
                    selectable = pointerEventData.pointerEnter.GetComponentInChildren<Selectable>();
                }
                pointerEventData.selectedObject = selectable.gameObject;
            }
        }

        protected virtual void OnDeselect(BaseEventData eventData)
        {
            Selectable selectable = eventData.selectedObject.GetComponent<Selectable>();
            _scaleDownTween = eventData.selectedObject.transform.DOScale(_defaultscales[selectable], _selectedScaleDuration);
        }

        protected virtual void OnSelect(BaseEventData eventData)
        {
            _lastSelected = eventData.selectedObject.GetComponent<Selectable>();
            Vector3 newScale = eventData.selectedObject.transform.localScale * _selectedScaleMultiplyer;
            _scaleUpTween = eventData.selectedObject.transform.DOScale(newScale, _selectedScaleDuration);
        }


        protected virtual void OnNavigate(InputAction.CallbackContext context)
        {
            if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == null && _lastSelected != null)
            {
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_lastSelected.gameObject);
            }
        }
    }
}
