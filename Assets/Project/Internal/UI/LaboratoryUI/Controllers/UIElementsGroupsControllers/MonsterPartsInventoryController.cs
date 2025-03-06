using System;
using System.Collections;
using System.Collections.Generic;
using Internal.GameStatics;
using Internal.MonsterPartSystem;
using Internal.Player;
using Internal.UI.EventSystem;
using Internal.UI.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.LaboratoryUI.Controllers
{
    public class MonsterPartsInventoryController : MonoBehaviour
    {
        private Inventory playerInventory;
        [SerializeField] public MonsterPartsInventoryEventsHandler MonsterPartsPanelEvents;

        [Range(1, 5), SerializeField] private int PartCategoryMaxItemsInRow = 4;

        private MonsterCreationControllerContext context;

        public IEnumerator Setup(Inventory playerInventory, MonsterCreationControllerContext context)
        {
            this.playerInventory = playerInventory;
            this.context = context;

            SetUpAllMonsterPartsSlots();
            StartCoroutine(SetupUISelectables());

            SetupSelectablesNavigations();

            yield return MonsterPartsPanelEvents.SetFirstSelected();
        }


        #region UiSetups
        public IEnumerator SetupUISelectables()
        {
            foreach (var category in context.PartCategories)
            {
                foreach (var item in category.CategoryItems)
                {
                    MonsterPartsPanelEvents.AddSelectable(item.GetComponent<Selectable>());
                }
            }
            yield return null;
        }

        public void SetUpAllMonsterPartsSlots()
        {
            foreach (var id in MonsterPartsRegistryCache.GetAllIDs())
            {

                // Trying to get part factory from the register by part id;
                SO_MonsterPartBase_Factory part_factory = MonsterPartsRegistryCache.GetByID(id);
                if (part_factory != null)
                {
                    // Grab a type of the part
                    MonsterPartType part_type = part_factory.PartType;

                    // Find appropriate category 
                    UIPartCategoryScript category = context.PartCategories.Find(o => o.PartType == part_type);

                    Transform target_transform = category.GetCategoryTransform();

                    if (target_transform != null)
                    {
                        var quantity = playerInventory.GetMonsterPartQuantity(id);

                        // Instantiate slot prefab inside of the target_transform if any exist.
                        var slot = Instantiate(context.InventorySlotPrefab, target_transform).GetComponent<MonsterPartInventorySlot>();

                        // Setup slot data
                        slot.Setup(id, quantity, part_factory.UI_Sprite_Unlocked, part_factory.UI_Sprite_Locked);

                        // Add slot's gameObject to CategoryItems of the appropriate category.
                        category.CategoryItems.Add(slot.gameObject);
                    }
                }
            }
        }

        public void SetupSelectablesNavigations()
        {
            var all_categories = new List<List<GameObject>>();
            foreach (var c in context.PartCategories)
            {
                all_categories.Add(c.CategoryItems);
            }
            StartCoroutine(BtnNavigationsUtility.CategoriesLike_Sel_Navigation(all_categories, PartCategoryMaxItemsInRow));
        }
        #endregion


        private void OnPartsQuantityChangedHandler(string PartID)
        {
            var NewQuantity = playerInventory.GetMonsterPartQuantity(PartID);

            foreach (var c in context.PartCategories)
            {
                foreach (var i in c.CategoryItems)
                {
                    if (c.TryGetComponent<MonsterPartInventorySlot>(out var item))
                    {
                        if (item.AttachedPartID == PartID)
                        {
                            item.UpdateCounter(NewQuantity);
                        }
                    }
                }
            }
        }


    }
}
