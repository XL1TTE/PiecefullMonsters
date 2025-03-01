using Internal.GameStatics;
using Internal.MonsterPartSystem;
using Internal.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal
{
    public class TestSystem : MonoBehaviour
    {

        public List<MonsterPartBase> Legs = new List<MonsterPartBase>();

        [ContextMenu("TestLeg")]
        public void TestMonsterLegAcess()
        {
            print("Ноги коровы до: " + PlayerCache.Data.GetInventory().GetMonsterPartQuantity("CowLeg"));

            var factory = MonsterPartsRegistryCache.GetByID("CowLeg");

            PlayerCache.Data.GetInventory().TryRemoveMonsterParts("CowLeg", 1);

            print("Ноги коровы после: " + PlayerCache.Data.GetInventory().GetMonsterPartQuantity("CowLeg"));

            if (factory != null)
            {
                var leg = factory.CreateInstance();
                Legs.Add(leg);

                string log = "";
                foreach (var i in Legs)
                {
                    log += $"{i}\n";
                }
                Debug.Log($"CowLeg was removed: \n {log}");
            }

        }
    }
}
