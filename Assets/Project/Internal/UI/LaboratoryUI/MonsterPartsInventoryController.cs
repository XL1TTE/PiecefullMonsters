using System.Collections;
using System.Collections.Generic;
using Internal.Player;
using UnityEngine;

namespace Internal.LaboratoryUI
{
    public class MonsterPartsInventoryController : MonoBehaviour
    {
        private Inventory playerInventory;
        private MonsterPartInventoryContext context;

        public void SetUP(Inventory playerInventory, MonsterPartInventoryContext context)
        {
            this.playerInventory = playerInventory;
            this.context = context;
        }

        private void OnPartsQuantityChangedHandler(string PartID)
        {
            var NewQuantity = playerInventory.GetMonsterPartQuantity(PartID);

            context.SlotsTemp.Find(o => o.AttachedPartID == PartID).UpdateCounter(NewQuantity);
        }
    }
}
