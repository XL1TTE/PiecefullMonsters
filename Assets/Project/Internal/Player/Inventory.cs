using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Player
{
    [Serializable]
    public class Inventory
    {
        private Dictionary<string, int> MonsterParts_IDQuantity_Pair = new();

        public int GetMonsterPartQuantity(string Part_ID)
        {
            if(MonsterParts_IDQuantity_Pair.TryGetValue(Part_ID, out var quantity))
            {
                return quantity;
            }
            return 0;
        }
        public bool TryAddMonsterParts(string Part_ID, int Quantity)
        {
            try
            {
                if (MonsterParts_IDQuantity_Pair.ContainsKey(Part_ID))
                {
                    MonsterParts_IDQuantity_Pair[Part_ID] += Quantity;
                    return true;
                }
                MonsterParts_IDQuantity_Pair.TryAdd(Part_ID, Quantity);
                return true;
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
