using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Modifiers_System
{
    [CreateAssetMenu(fileName = "StatModifier", menuName = "Modifiers/StatModifier")]
    public class ModifierAffectingStatValue_SO : ModifierBase_SO<ModifierBase>
    {
        public enum OperationType { Float, Multiply}

        [SerializeField] OperationType operationType;

        public override ModifierBase CreateModifierInstance()
        {
            var modifier = operationType switch
            {
                OperationType.Float => new StatValueChangeModifier(this.AffectedStatType, o => o + Value),
                OperationType.Multiply => new StatValueChangeModifier(this.AffectedStatType, o => o * Value),
                _ => throw new ArgumentOutOfRangeException()
            };

            return modifier;
        }
    }
}
