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
    public class MonsterCreationControllerContext
    {

        [SerializeField] public List<UIPartCategoryScript> PartCategories;

        [SerializeField] public MonsterPartInventorySlot InventorySlotPrefab;


    }
}
