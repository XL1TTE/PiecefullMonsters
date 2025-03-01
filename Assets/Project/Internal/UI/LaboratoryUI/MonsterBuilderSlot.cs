using System.Collections;
using System.Collections.Generic;
using Internal.GameStatics;
using Internal.MonsterPartSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Internal.LaboratoryUI
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class MonsterBuilderSlot : MonoBehaviour, IDropHandler
    {
        private MonsterPartInventorySlot_DraggedPart DataInSlot;
        [SerializeField] private MonsterPartType PartType;

        public void OnDrop(PointerEventData eventData)
        {
            var item = eventData.pointerDrag;

            if (item.TryGetComponent<MonsterPartInventorySlot_DraggedPart>(out DataInSlot) &&
                gameObject.transform.childCount < 1 &&
                MonsterPartsRegistryCache.GetByID(DataInSlot.AttachedSlot.AttachedPartID).PartType == this.PartType)
            {
                DataInSlot.WasPlacedInBuilder = true;
                DataInSlot.parentAfterDrag = gameObject.transform;


                Debug.Log($"{DataInSlot.AttachedSlot.AttachedPartID}");
            }
            return;
        }
    }
}
