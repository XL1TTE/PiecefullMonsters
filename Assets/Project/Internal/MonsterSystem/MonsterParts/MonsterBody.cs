using Internal.Modifiers_System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.MonsterPartSystem
{
    public class MonsterBody : MonsterPartBase
    {
        public MonsterBody(List<ModifierBase> modifiers, List<Vector2Int> attacks, List<Vector2Int> moves) : base(modifiers, attacks, moves)
        {
        }
    }
}
