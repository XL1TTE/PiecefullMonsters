using Internal.Modifiers_System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal
{
    public abstract class MonsterPartBase
    {
        public List<ModifierBase> modifiers = new();

        public List<Vector2Int> Attacks;
        public List<Vector2Int> Moves;

        public MonsterPartBase(List<ModifierBase> modifiers, List<Vector2Int> attacks, List<Vector2Int> moves)
        {
            this.modifiers = modifiers;
            Attacks = attacks;
            Moves = moves;
        }
    }
}
