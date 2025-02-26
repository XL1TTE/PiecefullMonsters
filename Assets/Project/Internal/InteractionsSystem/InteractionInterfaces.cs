using System.Collections;
using System.Collections.Generic;
using Internal.GameInitialization;
using Internal.GameInitialization.Contexts;
using UnityEngine;

namespace Internal.InteractionsSystem
{
    public interface IOnGameInitialize
    {
        public IEnumerator OnGameInitialize(GameDataInitializer context);
    }
}
