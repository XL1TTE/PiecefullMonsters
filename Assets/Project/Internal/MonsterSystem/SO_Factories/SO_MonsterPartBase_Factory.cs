using Internal.Modifiers_System;
using Internal.MonsterPartSystem.MoveSetSchemes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.MonsterPartSystem
{

    public enum MonsterPartType
    {
        leg,
        Arm,
        Body,
        Head,
    }

    public abstract class SO_MonsterPartBase_Factory : ScriptableObject
    {
        [SerializeField] public Sprite Sprite;
        [SerializeField] public Sprite UI_Sprite_Unlocked;
        [SerializeField] public Sprite UI_Sprite_Locked;

        [SerializeField] public MonsterPartType PartType;

        [SerializeField] protected List<ModifierAffectingStatValue_SO> modifiers;

        [SerializeField] protected AttackScheme_SO AttackSceme;
        [SerializeField] protected MoveScheme_SO MoveScheme;

        public abstract MonsterPartBase CreateInstance();
    }
}
