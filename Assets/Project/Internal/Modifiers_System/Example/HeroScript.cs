using Internal.Modifiers_System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Internal.Modifiers_System
{
    public class HeroScript : MonoBehaviour
    {
        [SerializeField] BaseStats_SO defaultStats;
        public Stats Stats { get; private set; }

        public List<TestEquip_SO> Equips;

        private void Awake()
        {
            Stats = new Stats(defaultStats, new StatsMediator());

            foreach(var e in Equips)
            {
                foreach(var mod in e.StatsModifiers)
                {
                    Stats.mediator.AddModifier(mod.CreateModifierInstance());
                }
            }
        }

        public void Update()
        {
            Stats.mediator.Update(Time.deltaTime);
        }

        [ContextMenu("Show Stats")]
        public void ShowStats()
        {
            var res = $"Скорость - {Stats.Speed}\n Сила - {Stats.Strengh}";
            print(res);
        }
    }
}
