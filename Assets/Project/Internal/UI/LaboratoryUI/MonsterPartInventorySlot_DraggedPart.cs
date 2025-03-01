using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Internal.LaboratoryUI
{
    public class MonsterPartInventorySlot_DraggedPart : MonoBehaviour, IPointerClickHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public MonsterPartInventorySlot AttachedSlot;
        [SerializeField] private Image item_sprite_placeholder;

        [SerializeField] private Transform OriginalSlotTransform;

        private Vector3 originalPosition;
        [HideInInspector] public Transform parentAfterDrag;

        private Image TriggerImage;
        [HideInInspector] public bool WasPlacedInBuilder;
        void Awake()
        {
            item_sprite_placeholder.gameObject.SetActive(false);
            TriggerImage = gameObject.GetComponent<Image>();
        }
        public void AttachSlot(MonsterPartInventorySlot slot)
        {
            AttachedSlot = slot;
            item_sprite_placeholder.sprite = slot.UnlockedSprite;
        }

        private void SwitchVisability(bool isVisible)
        {
            item_sprite_placeholder.gameObject.SetActive(isVisible);
            SwitchTriggerState(!isVisible);
        }

        private void SwitchTriggerState(bool isTrigger)
        {
            TriggerImage.raycastTarget = isTrigger;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("sadawffawf");
        }


        public void OnBeginDrag(PointerEventData eventData)
        {

            if (!WasPlacedInBuilder && AttachedSlot.Quantity < 0)
            {
                return;
            }

            if (!WasPlacedInBuilder)
            {
                AttachedSlot.Quantity--;
            }


            originalPosition = gameObject.transform.position;
            parentAfterDrag = gameObject.transform.parent;

            SwitchVisability(true);

            transform.SetParent(transform.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (AttachedSlot.Quantity < 0)
            {
                return;
            }
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (AttachedSlot.Quantity < 0)
            {
                return;
            }
            if (!WasPlacedInBuilder)
            {
                AttachedSlot.Quantity++;
                SwitchVisability(false);
            }
            else
            {
                if (OriginalSlotTransform.childCount == 0 && AttachedSlot.Quantity > 0)
                {
                    var copy = Instantiate(this, transform.position, transform.rotation, OriginalSlotTransform);
                    copy.WasPlacedInBuilder = false;
                    copy.SwitchTriggerState(true);
                }
            }

            SwitchTriggerState(true);
            transform.SetParent(parentAfterDrag);
            transform.position = originalPosition;
        }

    }
}
