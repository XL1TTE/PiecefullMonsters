using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Internal.LaboratoryUI
{
    public class MonsterPart_UIslot_Controller : MonoBehaviour, IPointerClickHandler
    {
        [HideInInspector] public Sprite UnlockedSprite;
        [SerializeField] private Sprite LockedSprite;

        [SerializeField] private Image SpriteHolder;
        [SerializeField] public TextMeshProUGUI QuantityCounter;

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
                SpriteHolder.sprite = _isLocked ? LockedSprite : UnlockedSprite;
            }
        }


        [HideInInspector] public string AttachedPartID;


        public void UpdateCounter(int quantity)
        {
            Quantity = quantity;
        }

        public void Setup(string PartID, int quantity, Sprite PartSprite)
        {
            UnlockedSprite = PartSprite;
            AttachedPartID = PartID;
            Quantity = quantity;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Quantity--;
        }
    }
}
