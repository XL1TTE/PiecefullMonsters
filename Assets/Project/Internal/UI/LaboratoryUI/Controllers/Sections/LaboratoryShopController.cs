using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.LaboratoryUI.Controllers
{
    public class LaboratoryShopController : SectionControllerBase
    {

        [Header("Navigation Buttons Refs")]
        [SerializeField] private Button ToMonsterCreation;

        #region Navigation Actions
        private void NavigateToMonsterCreation()
        {

            var map = LaboratoryController.instance.UISectionsMapper;
            if (map != null)
            {
                map.MoveToSectionInDirection(Vector2Int.down, LaboratoryController.instance.MonsterCreationController);
            }
        }
        #endregion

        private void SetupNavButtons()
        {
            ToMonsterCreation.onClick.AddListener(NavigateToMonsterCreation);
        }


        public override void DisableUIBehaviour()
        {
            Debug.Log("Disable shop behaviour");
        }

        public override void EnableUIBehaviour()
        {
            Debug.Log("Enable shop behaviour");
        }

        public override void Setup_UI()
        {
            Debug.Log("Setup shop ui");
            SetupNavButtons();
        }
    }
}
