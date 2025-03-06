using System;
using System.Collections;
using System.Collections.Generic;
using Internal.GameStatics;
using Internal.LaboratoryUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Internal.UI.EventSystem
{
    public class MonsterBuilderSlotsEventsHandler : UI_EventSystemHandler
    {
        [SerializeField] Color SelectedColor;
        [SerializeField] Color DeselectedColor;

        protected override void AddListeners(Selectable selectable)
        {
            base.AddListeners(selectable);
            var slot = selectable.gameObject.GetComponent<MonsterBuilderSlot>();
            if (slot != null)
            {
                slot.SlotSpriteHolder.color = DeselectedColor;
            }
        }

        protected override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            var slot = eventData.selectedObject.GetComponent<MonsterBuilderSlot>();
            if (slot != null)
            {
                slot.SlotSpriteHolder.color = SelectedColor;
            }
        }

        protected override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
            var slot = eventData.selectedObject.GetComponent<MonsterBuilderSlot>();
            if (slot != null)
            {
                slot.SlotSpriteHolder.color = DeselectedColor;
            }
        }
    }
}
