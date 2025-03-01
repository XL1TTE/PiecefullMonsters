using System;
using System.Collections;
using System.Collections.Generic;
using Internal.GameStatics;
using Internal.InteractionsSystem;
using Internal.Player;
using UnityEngine;
using UnityEngine.UIElements;

namespace Internal.LaboratoryUI
{

    [Serializable]
    public class MonsterPartInventoryContext
    {

        [SerializeField] public List<UIPartCategoryScript> PartCategories;

        [SerializeField] public MonsterPartInventorySlot InventorySlotPrefab;
        [HideInInspector] public List<MonsterPartInventorySlot> SlotsTemp = new();
    }
}
