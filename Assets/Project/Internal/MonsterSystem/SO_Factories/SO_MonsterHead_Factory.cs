using System.Collections;
using System.Collections.Generic;
using Internal.Modifiers_System;
using UnityEngine;

namespace Internal.MonsterPartSystem
{
    [CreateAssetMenu(fileName = "MonsterHead", menuName = "MonsterParts/HeadFactory")]
    public class SO_MonsterHead_Factory : SO_MonsterPartBase_Factory
    {
        public override MonsterPartBase CreateInstance()
        {
            List<ModifierBase> _modifiers = new();
            foreach (var mod in modifiers)
            {
                _modifiers.Add(mod.CreateModifierInstance());
            }

            return new MonsterHead(
                    _modifiers,
                    AttackSceme.MapToVector2s(),
                    MoveScheme.MapToVector2s()
                );
        }
    }
}
