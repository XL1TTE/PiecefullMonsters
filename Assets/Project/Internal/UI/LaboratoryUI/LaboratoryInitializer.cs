using System.Collections;
using System.Collections.Generic;
using Internal.GameStatics;
using Internal.InteractionsSystem;
using Internal.MonsterPartSystem;
using Internal.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Internal.LaboratoryUI.Initialization
{

    public class OnLaboratoryUIInitializeInteraction : BaseInteraction, IOnLaboratoryUIInitializing
    {
        public IEnumerator OnInitialize(LaboratoryInitializer context)
        {
            yield return context.SetUpAllMonsterPartsSlots();

            context.monsterPartsInventoryController.SetUP(context.PlayerInventory, context.monsterPartsInventoryContext);


            yield return null;
        }
    }

    public class LaboratoryInitializer : MonoBehaviour
    {
        [SerializeField] public MonsterPartInventoryContext monsterPartsInventoryContext;

        [SerializeField] public MonsterPartsInventoryController monsterPartsInventoryController;

        [HideInInspector] public Inventory PlayerInventory;

        IEnumerator Start()
        {
            // Initialize Self
            yield return InitializeSelf();

            // Inject interactions
            InteractionsManager intm = new InteractionsManager();
            intm.Init();


            // Laboratory UI Initializing
            var init_interactions = intm.GetAllOf<IOnLaboratoryUIInitializing>();
            foreach (var record in init_interactions)
            {
                yield return record.OnInitialize(this);
            }
        }

        private IEnumerator InitializeSelf()
        {
            PlayerInventory = PlayerCache.Data.GetInventory();
            yield return null;
        }

        public IEnumerator SetUpAllMonsterPartsSlots()
        {
            foreach (var id in MonsterPartsRegistryCache.GetAllIDs())
            {
                SO_MonsterPartBase_Factory part_factory = MonsterPartsRegistryCache.GetByID(id);
                if (part_factory != null)
                {
                    MonsterPartType part_type = part_factory.PartType;
                    UIPartCategoryScript category = monsterPartsInventoryContext.PartCategories.Find(o => o.PartType == part_type);

                    Transform target_transform = category.GetCategoryTransform();

                    var quantity = PlayerInventory.GetMonsterPartQuantity(id);


                    var temp = Instantiate(monsterPartsInventoryContext.InventorySlotPrefab, target_transform).GetComponent<MonsterPartInventorySlot>();
                    temp.Setup(id, quantity, part_factory.UI_Sprite_Unlocked, part_factory.UI_Sprite_Locked);

                    monsterPartsInventoryContext.SlotsTemp.Add(temp);
                }
            }
            yield return null;
        }

    }
}
