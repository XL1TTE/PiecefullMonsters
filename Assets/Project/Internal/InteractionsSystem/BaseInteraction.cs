using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.InteractionsSystem
{
    public abstract class BaseInteraction 
    {

        public virtual int Priority()
        {
            return 0;
        }
    }
}
