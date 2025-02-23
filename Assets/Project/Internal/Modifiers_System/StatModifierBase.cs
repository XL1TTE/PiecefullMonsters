using Internal.Modifiers_System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Modifiers_System
{
    public abstract class ModifierBase : IDisposable
    {
        public string Name;
        public string Description;

        public event Action<ModifierBase> OnDispose = delegate { };

        public bool isMarkedForRemoval { get; private set; }

        public event Action<ModifierBase> OnMarkedForRemoval = delegate { };

        protected void MarkForRemoval()
        {
            isMarkedForRemoval = true;
            OnMarkedForRemoval.Invoke(this);
        }

        public abstract void Handle(object sender, Query query);

        public void Dispose()
        {
            OnDispose.Invoke(this);
        }

    }
}
