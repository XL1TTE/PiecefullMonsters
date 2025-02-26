using System;
using System.Collections;
using System.Collections.Generic;
using Internal.Player;
using UnityEngine;

namespace Internal.GameInitialization.Contexts
{

    [Serializable]
    public class MonsterPartID_Quantity_Pair
    {
        public string ID;
        public int Quantity;
    }

    [Serializable]
    public class PlayerDataInit_Context
    {
        [SerializeField] List<MonsterPartID_Quantity_Pair> StandartMonsterPartsKit = new();

        public PlayerData CreateNewPlayerData()
        {
            var inventory = new Inventory();

            var playerData = new PlayerData(
                inventory
                );


            return playerData;
        }

        public void FillInventoryWithStandartMonsterParts(Inventory inventory)
        {
            foreach (var pair in StandartMonsterPartsKit)
            {
                inventory.TryAddMonsterParts(pair.ID, pair.Quantity);
            }
        }
    }
}
