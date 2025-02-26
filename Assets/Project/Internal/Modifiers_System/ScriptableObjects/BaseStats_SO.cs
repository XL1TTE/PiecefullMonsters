using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Modifiers_System
{

    [CreateAssetMenu(fileName = "BaseStats", menuName = "Modifiers/BaseStats")]
    public class BaseStats_SO : ScriptableObject
    {
        [Range(0f, 100f)] public int Strengh = 0;
        [Range(0f, 100f)] public int Intelligence = 0;
        [Range(0f, 100f)] public int Speed = 0;
    }
}
