using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Internal.LaboratoryUI
{


    public class MonsterPartInventorySlot : MonoBehaviour, IDropHandler
    {

        [HideInInspector] public Sprite UnlockedSprite;
        [HideInInspector] private Sprite LockedSprite;

        [SerializeField] public Image ItemSpriteHolder;
        [SerializeField] public Image SlotSpriteHolder;
        [SerializeField] public TextMeshProUGUI QuantityCounter;

        [SerializeField] private Transform DraggedPartSlot;

        [HideInInspector] public string AttachedPartID;

        private int _quantity = 0;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                QuantityCounter.text = _quantity.ToString();
                IsLocked = _quantity > 0 ? false : true;
            }
        }

        private bool _isLocked = true;
        public bool IsLocked
        {
            get => _isLocked;
            set
            {
                _isLocked = value;
                ItemSpriteHolder.sprite = _isLocked ? LockedSprite : UnlockedSprite;
            }
        }


        public void UpdateCounter(int quantity)
        {
            Quantity = quantity;
        }


        public void Setup(string PartID, int quantity, Sprite PartSprite, Sprite lockedSprite)
        {
            UnlockedSprite = PartSprite;
            LockedSprite = lockedSprite;
            AttachedPartID = PartID;

            // drag part setup
            var drag_part = GetComponentInChildren<MonsterPartInventorySlot_DraggedPart>();
            drag_part.AttachSlot(this);

            Quantity = quantity;

        }


        public void OnDrop(PointerEventData eventData)
        {
            var item = eventData.pointerDrag;

            if (item.TryGetComponent<MonsterPartInventorySlot_DraggedPart>(out var draged_item))
            {

                if (draged_item.AttachedSlot.AttachedPartID != AttachedPartID)
                {
                    return;
                }

                if (DraggedPartSlot.childCount > 0)
                {
                    Destroy(draged_item.gameObject);
                    Quantity++;
                    return;
                }

                draged_item.WasPlacedInBuilder = false;

                draged_item.parentAfterDrag = DraggedPartSlot;
            }
            return;
        }
    }
}
