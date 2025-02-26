using Internal.GameStatics;
using Internal.MonsterPartSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal
{
    public class TestSystem : MonoBehaviour
    {

        public List<MonsterLeg> Legs = new List<MonsterLeg>();

        [ContextMenu("TestLeg")]
        public void TestMonsterLegAcess()
        {
            var factory = MonsterPartsRegistry.Instance().Legs.GetByID("CowLeg");

            if(factory != null)
            {
                var leg = factory.CreateInstance();
                Legs.Add(leg);

                string log = "";
                foreach(var i in Legs)
                {
                    log += $"{i}\n";
                }
                Debug.Log($"CowLeg была успешно добавлена! Теперь список ног выглядит так: \n {log}");
            }

        }
    }
}
