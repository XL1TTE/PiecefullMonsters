using System.Collections;
using System.Collections.Generic;
using Internal.Player;
using Internal.UI;
using Internal.UI.EventSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.LaboratoryUI.Controllers
{

    public class MonsterCreationController : SectionControllerBase
    {
        [Header("Ui elements controllers")]
        [SerializeField] private MonsterPartsInventoryController MonsterPartsUI_Controller;
        [SerializeField] private MonsterBuilderController MonsterBuilderUI_Controller;


        [Header("MonsterCreationSectionContext")]
        [SerializeField] private MonsterCreationControllerContext context;

        [Header("Navigation Buttons Refs")]
        [SerializeField] private Button ToShopButton;

        #region Navigation Actions
        private void NavigateToShop()
        {

            var map = LaboratoryController.instance.UISectionsMapper;
            if (map != null)
            {
                map.MoveToSectionInDirection(Vector2Int.up, LaboratoryController.instance.LaboratoryShopController);
            }
        }
        #endregion

        private void SetupNavButtons()
        {
            ToShopButton.onClick.AddListener(NavigateToShop);
        }

        public override void Setup_UI()
        {
            if (MonsterPartsUI_Controller != null)
            {
                Inventory player_inventory = PlayerCache.Data.GetInventory();

                StartCoroutine(MonsterPartsUI_Controller.Setup(player_inventory, context));
            }
            else
            {
                Debug.LogError("MonsterPartsUI_Controller not specified!");
            }
            SetupNavButtons();
        }

        public override void DisableUIBehaviour()
        {
            MonsterPartsUI_Controller.MonsterPartsPanelEvents.DisableBehaviour();
            MonsterBuilderUI_Controller.BuiderSlotsEvents.DisableBehaviour();
        }

        public override void EnableUIBehaviour()
        {
            MonsterPartsUI_Controller.MonsterPartsPanelEvents.EnableBehaviour();
            MonsterBuilderUI_Controller.BuiderSlotsEvents.EnableBehaviour();
        }
    }
}
