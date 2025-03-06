using System.Collections;
using System.Collections.Generic;
using Internal.LaboratoryUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Internal.UI.EventSystem
{
    public class MonsterBuilderSlotsEventsHandler : UI_DynamicEventSystemHandler
    {
        [SerializeField] Color SelectedColor;
        [SerializeField] Color DeselectedColor;

        protected override void AddListeners(Selectable selectable)
        {
            base.AddListeners(selectable);
        }

        protected override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            var slot = eventData.selectedObject.GetComponent<MonsterPartInventorySlot>();
            if (slot != null)
            {
                slot.ItemSpriteHolder.color = SelectedColor;
                slot.SlotSpriteHolder.color = SelectedColor;
            }
        }

        protected override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
            var slot = eventData.selectedObject.GetComponent<MonsterPartInventorySlot>();
            if (slot != null)
            {
                slot.ItemSpriteHolder.color = DeselectedColor;
                slot.SlotSpriteHolder.color = DeselectedColor;
            }
        }
    }
}
