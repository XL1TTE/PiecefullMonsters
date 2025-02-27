using System.Collections;
using System.Collections.Generic;
using Internal.GameStatics;
using Internal.Player;
using UnityEngine;

namespace Internal.LaboratoryUI
{
    public class LaboratoryPartsController : MonoBehaviour
    {
        [SerializeField] Transform Heads;
        [SerializeField] Transform Bodies;
        [SerializeField] Transform Arms;
        [SerializeField] Transform Legs;

        [SerializeField] GameObject MonsterPart_CategoriesUI_Prefab;

        private Inventory PlayerInventory;


        private List<MonsterPart_UIslot_Controller> AllSlots = new();


        void Awake()
        {
            try
            {
                MonsterPart_CategoriesUI_Prefab.GetComponent<MonsterPart_UIslot_Controller>();
            }
            catch
            {
                Debug.LogError("MonsterPart_CategoriesUI_Prefab must have the MonsterPart_UIslot_Controller!");
            }

        }

        void OnEnable()
        {

            // Make with event of inventoryChanged to update PlayerInventory
            PlayerInventory = PlayerCache.Data.GetInventory();

            PlayerInventory.PartsQuantityChanged += OnPartsQuantityChangedHandler;

            SetUpAll_UISlots();
        }

        void OnDisable()
        {
            PlayerInventory.PartsQuantityChanged -= OnPartsQuantityChangedHandler;
        }

        private void OnPartsQuantityChangedHandler(string PartID)
        {
            var NewQuantity = PlayerInventory.GetMonsterPartQuantity(PartID);

            AllSlots.Find(o => o.AttachedPartID == PartID).UpdateCounter(NewQuantity);
        }

        private void SetUpAll_UISlots()
        {
            SetUP_HeadSlots();
            SetUP_BodySlots();
            SetUP_ArmSlots();
            SetUP_LegSlots();
        }

        private void SetUP_HeadSlots()
        {
            foreach (var head_id in MonsterPartsRegistryCache.Heads().GetAllIDs())
            {
                var quant = PlayerInventory.GetMonsterPartQuantity(head_id);

                var part_data = MonsterPartsRegistryCache.Heads().GetByID(head_id);

                if (part_data != null)
                {
                    var temp = Instantiate(MonsterPart_CategoriesUI_Prefab, Heads).GetComponent<MonsterPart_UIslot_Controller>();
                    temp.Setup(head_id, quant, part_data.UI_Sprite);

                    AllSlots.Add(temp);
                }
            }
        }
        private void SetUP_BodySlots()
        {
            foreach (var body_id in MonsterPartsRegistryCache.Bodies().GetAllIDs())
            {
                var quant = PlayerInventory.GetMonsterPartQuantity(body_id);

                var part_data = MonsterPartsRegistryCache.Bodies().GetByID(body_id);

                if (part_data != null)
                {
                    var temp = Instantiate(MonsterPart_CategoriesUI_Prefab, Bodies).GetComponent<MonsterPart_UIslot_Controller>();
                    temp.Setup(body_id, quant, part_data.UI_Sprite);

                    AllSlots.Add(temp);
                }
            }
        }
        private void SetUP_ArmSlots()
        {
            foreach (var arm_id in MonsterPartsRegistryCache.Arms().GetAllIDs())
            {
                var quant = PlayerInventory.GetMonsterPartQuantity(arm_id);

                var part_data = MonsterPartsRegistryCache.Arms().GetByID(arm_id);

                if (part_data != null)
                {
                    var temp = Instantiate(MonsterPart_CategoriesUI_Prefab, Arms).GetComponent<MonsterPart_UIslot_Controller>();
                    temp.Setup(arm_id, quant, part_data.UI_Sprite);

                    AllSlots.Add(temp);
                }
            }
        }
        private void SetUP_LegSlots()
        {
            foreach (var leg_id in MonsterPartsRegistryCache.Legs().GetAllIDs())
            {
                var quant = PlayerInventory.GetMonsterPartQuantity(leg_id);

                var part_data = MonsterPartsRegistryCache.Legs().GetByID(leg_id);

                if (part_data != null)
                {
                    var temp = Instantiate(MonsterPart_CategoriesUI_Prefab, Legs).GetComponent<MonsterPart_UIslot_Controller>();
                    temp.Setup(leg_id, quant, part_data.UI_Sprite);

                    AllSlots.Add(temp);
                }
            }
        }
    }
}
