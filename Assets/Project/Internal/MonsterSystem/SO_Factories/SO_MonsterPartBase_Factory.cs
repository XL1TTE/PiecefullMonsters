using Internal.Modifiers_System;
using Internal.MonsterPartSystem.MoveSetSchemes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.MonsterPartSystem
{
    public abstract class SO_MonsterPartBase_Factory<PartType> : ScriptableObject
    {
        [SerializeField] public Sprite Sprite;
        [SerializeField] public Sprite UI_Sprite;

        [SerializeField] protected List<ModifierAffectingStatValue_SO> modifiers;

        [SerializeField] protected AttackScheme_SO AttackSceme;
        [SerializeField] protected MoveScheme_SO MoveScheme;

        public abstract PartType CreateInstance();
    }
}
