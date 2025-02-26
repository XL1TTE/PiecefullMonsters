using System;
using System.Collections;
using System.Collections.Generic;
using Internal.GameInitialization.Contexts;
using Internal.InteractionsSystem;
using Internal.Player;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace Internal.GameInitialization
{

    class PlayerInitInteraction : BaseInteraction, IOnGameInitialize
    {
        public override Priorities Priority()
        {
            return Priorities.very_low;
        }
        public IEnumerator OnGameInitialize(GameDataInitializer context)
        {

            // CHECK IF THERE ANY GAME SAVE AND IF IT IS LOAD DATA FROM THERE!!!

            // Inititalizing new player data if the saves was not founded.
            var PlayerData = context.PlayerDataContext.CreateNewPlayerData();
            context.PlayerDataContext.FillInventoryWithStandartMonsterParts(PlayerData.GetInventory());


            // Set static PlayerCache.Data cache to access it later...
            PlayerCache.Data = PlayerData;

            yield return null;
        }
    }


    class MosnsterPartsInitInteraction : BaseInteraction, IOnGameInitialize
    {
        public override Priorities Priority()
        {
            return Priorities.low;
        }
        public IEnumerator OnGameInitialize(GameDataInitializer context)
        {
            context.MonstersPartsContext.CacheMonsterPartsRegistry();

            yield return null;
        }
    }

    public class GameDataInitializer : MonoBehaviour
    {

        [SerializeField]
        public PlayerDataInit_Context PlayerDataContext;

        [SerializeField]
        public MonstersPartsInit_Context MonstersPartsContext;

        private IEnumerator Start()
        {
            if (PlayerDataContext == null)
            {
                Debug.LogError("Player data initialization context must be provided to Game Data Initializer!!!");
                yield return null;
            }
            yield return Initialize();
        }


        private IEnumerator Initialize()
        {
            InteractionsManager intm = new InteractionsManager();
            intm.Init();

            var interactions = intm.GetAllOf<IOnGameInitialize>();

            foreach (var i in interactions)
            {
                yield return i.OnGameInitialize(this);
            }


            LoadGame();
        }

        private void LoadGame()
        {
            try
            {
                ScenesTransitionManager.ST_SingleMode_WithLoadingScreenAsync("MonstersSystemTEST_SCENE", "default");
            }
            catch
            {
                Debug.LogError("Scene Transition Manager must be on scene to start game loading.");
            }
        }
    }
}
