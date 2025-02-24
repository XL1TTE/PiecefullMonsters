using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal
{
    public abstract class Grid_ABS : MonoBehaviour
    {
        [NonSerialized]
        public int Height;
        [NonSerialized]
        public int Width;
        public List<bool> Cells;
    }
}
