using System.Collections;

using Internal.InteractionsSystem;
using Internal.LaboratoryUI.Controllers;

using Internal.Player;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace Internal.LaboratoryUI.Initialization
{

    public class OnLaboratoryUIInitializeInteraction : BaseInteraction, IOnLaboratoryUIInitializingStart
    {
        public IEnumerator OnInitialize(LaboratoryInitializer context)
        {
            context.MonsterCreationController.Setup_UI();
            context.LaboratoryShopController.Setup_UI();

            yield return null;
        }
    }

    public class OnLaboratoryUiInitialized : BaseInteraction, IOnLaboratoryUIInitialized
    {
        public IEnumerator OnInitialized(LaboratoryInitializer context)
        {

            yield return context.LaboratoryController.Init();
        }
    }

    public class LaboratoryInitializer : MonoBehaviour
    {

        [Header("Controllers Setup")]

        [SerializeField] public LaboratoryController LaboratoryController;
        [SerializeField] public MonsterCreationController MonsterCreationController;
        [SerializeField] public LaboratoryShopController LaboratoryShopController;


        IEnumerator Start()
        {
            // Inject interactions
            InteractionsManager intm = new InteractionsManager();
            intm.Init();


            // Laboratory UI Initializing
            var init_interactions = intm.GetAllOf<IOnLaboratoryUIInitializingStart>();
            foreach (var record in init_interactions)
            {
                yield return record.OnInitialize(this);
            }

            // After Laboratory UI Initialized
            var after_init_interactions = intm.GetAllOf<IOnLaboratoryUIInitialized>();
            foreach (var record in after_init_interactions)
            {
                yield return record.OnInitialized(this);
            }
        }

    }
}
