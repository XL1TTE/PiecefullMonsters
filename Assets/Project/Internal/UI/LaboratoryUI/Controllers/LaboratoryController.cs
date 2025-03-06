using System.Collections;
using System.Collections.Generic;
using Internal.UI;
using UnityEngine;

namespace Internal.LaboratoryUI.Controllers
{
    public class LaboratoryController : MonoBehaviour
    {
        public static LaboratoryController instance;

        [SerializeField] public UIMapper UISectionsMapper;

        [SerializeField] public MonsterCreationController MonsterCreationController;
        [SerializeField] public LaboratoryShopController LaboratoryShopController;

        public IEnumerator Init()
        {
            yield return UISectionsMapper.Init(MonsterCreationController);

            UISectionsMapper.CurrentSectionController.EnableUIBehaviour();
            UISectionsMapper.CurrentSectionControllerChanged += OnActiveLavoratorySectionChange;

            if (instance == null)
            {
                instance = this;
            }
        }

        private void OnActiveLavoratorySectionChange()
        {
            UISectionsMapper.PrevSectionController.DisableUIBehaviour();
            UISectionsMapper.CurrentSectionController.EnableUIBehaviour();
        }

    }
}
