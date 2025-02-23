using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Player
{
    [Serializable]
    public class MonsterPartID_Quantity_Pair
    {
        public string ID;
        public int Quantity;
    }

    public class PlayerDataLoader : MonoBehaviour
    {
        PlayerData _playerData;

        [SerializeField] List<MonsterPartID_Quantity_Pair> StandartMonsterPartsKit = new();

        private void Awake()
        {
            // Load PlayerData from any source...
            _playerData = InitializePlayerData();

            // Destroy object after initialization...
        }

        private void Start()
        {
            PlayerDataHolder.Instance().SetPlayerData(_playerData);
            Destroy(this.gameObject);
        }

        private PlayerData InitializePlayerData()
        {
            var inventory = new Inventory();
            FillInventoryWithStandartMonsterParts(ref inventory);

            var playerData = new PlayerData(
                inventory
                );


            return playerData;
        }

        private void FillInventoryWithStandartMonsterParts(ref Inventory inventory)
        {
            foreach (var pair in StandartMonsterPartsKit) {
                inventory.TryAddMonsterParts(pair.ID, pair.Quantity);
            }
        }
    }
}
