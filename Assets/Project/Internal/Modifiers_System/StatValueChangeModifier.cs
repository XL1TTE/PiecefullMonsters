using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.HDROutputUtils;

namespace Internal.Modifiers_System
{
    public class StatValueChangeModifier : ModifierBase
    {
        private StatType _statType;
        private Func<float, float> _operation;

        public StatValueChangeModifier(StatType StatType, Func<float, float> operation)
        {
            _statType = StatType;
            _operation = operation;
        }

        public override void Handle(object sender, Query query)
        {
            MarkForRemoval();
            if(query.AffectedStatType == _statType)
            {
                query.Value = _operation(query.Value);
            }
        }
    }
}
