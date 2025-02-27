using System;
using System.Collections.Generic;


namespace Internal.Player
{



    [Serializable]
    public class Inventory
    {
        private Dictionary<string, int> MonsterParts_IDQuantity_Pair = new();

        public event Action<string> PartsQuantityChanged;

        private void OnPartsQuantityChanged(string PartID)
        {
            PartsQuantityChanged?.Invoke(PartID);
        }

        public int GetMonsterPartQuantity(string Part_ID)
        {
            if (MonsterParts_IDQuantity_Pair.TryGetValue(Part_ID, out var quantity))
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
                    OnPartsQuantityChanged(Part_ID);
                    return true;
                }
                MonsterParts_IDQuantity_Pair.TryAdd(Part_ID, Quantity);
                OnPartsQuantityChanged(Part_ID);
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }

        }

        public bool TryRemoveMonsterParts(string Part_ID, int Quantity)
        {
            try
            {
                if (MonsterParts_IDQuantity_Pair.ContainsKey(Part_ID))
                {
                    var current_q = MonsterParts_IDQuantity_Pair[Part_ID];

                    if (current_q - Quantity > 0)
                    {
                        MonsterParts_IDQuantity_Pair[Part_ID] -= Quantity;
                    }

                    return false;
                }
                OnPartsQuantityChanged(Part_ID);

                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
