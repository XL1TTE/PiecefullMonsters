using System.Collections;
using System.Collections.Generic;
using Internal.Modifiers_System;
using Internal.MonsterPartSystem;
using UnityEngine;

namespace Internal.MonsterPartSystem
{
    [CreateAssetMenu(fileName = "MonsterArm", menuName = "MonsterParts/ArmFactory")]
    public class SO_MonsterArm_Factory : SO_MonsterPartBase_Factory
    {
        public override MonsterPartBase CreateInstance()
        {

            List<ModifierBase> _modifiers = new();
            foreach (var mod in modifiers)
            {
                _modifiers.Add(mod.CreateModifierInstance());
            }


            return new MonsterArm(
                _modifiers,
                base.AttackSceme.MapToVector2s(),
                base.MoveScheme.MapToVector2s()
            );
        }
    }
}
