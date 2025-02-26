using Internal.Modifiers_System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal
{
    [CreateAssetMenu(fileName = "Equp_01", menuName = "Test/Equip")]
    public class TestEquip_SO : ScriptableObject
    {
        public List<ModifierAffectingStatValue_SO> StatsModifiers;


    }
}
