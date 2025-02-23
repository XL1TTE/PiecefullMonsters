using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Player
{
    [Serializable]
    public class PlayerData
    {
        public PlayerData(Inventory inventory)
        {
            _inventory = inventory;
        }

        private Inventory _inventory;

        public Inventory GetInventory()
        {
            return _inventory;
        }
    }
}
