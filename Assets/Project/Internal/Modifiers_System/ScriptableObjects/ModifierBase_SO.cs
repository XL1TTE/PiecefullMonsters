using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Modifiers_System
{
    public abstract class ModifierBase_SO<ModifierBaseType> : ScriptableObject
    {
        public string Name;
        public string Description;

        public StatType AffectedStatType;
        public float Value;


        public abstract ModifierBaseType CreateModifierInstance();
    }
}
