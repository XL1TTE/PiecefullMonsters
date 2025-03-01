using Internal.Modifiers_System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.MonsterPartSystem
{
    [CreateAssetMenu(fileName = "MonsterLeg", menuName = "MonsterParts/LegFactory")]
    public class SO_MonsterLeg_Factory : SO_MonsterPartBase_Factory
    {
        public override MonsterPartBase CreateInstance()
        {
            List<ModifierBase> _modifiers = new();
            foreach (var mod in modifiers)
            {
                _modifiers.Add(mod.CreateModifierInstance());
            }

            return new MonsterLeg(
                    _modifiers,
                    AttackSceme.MapToVector2s(),
                    MoveScheme.MapToVector2s()
                );
        }
    }
}
