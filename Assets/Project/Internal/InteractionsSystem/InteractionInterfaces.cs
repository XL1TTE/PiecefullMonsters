using System.Collections;
using System.Collections.Generic;
using Internal.GameInitialization;
using Internal.GameInitialization.Contexts;
using Internal.LaboratoryUI;
using Internal.LaboratoryUI.Initialization;
using UnityEngine;

namespace Internal.InteractionsSystem
{
    public interface IOnGameInitialize
    {
        public IEnumerator OnGameInitialize(GameDataInitializer context);
    }

    public interface IOnLaboratoryUIInitializingStart
    {
        public IEnumerator OnInitialize(LaboratoryInitializer context);
    }

    public interface IOnLaboratoryUIInitialized
    {
        public IEnumerator OnInitialized(LaboratoryInitializer context);
    }


}
