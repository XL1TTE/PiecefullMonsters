using Internal.Utilities;
using System;
using System.Collections.Generic;


namespace Internal.InteractionsSystem
{
    public class InteractionsManager
    {
        public readonly List<BaseInteraction> all_interactions = new();
        public void Init()
        {
            var types = ReflectionUtility.GetSubclassesOf<BaseInteraction>();

            foreach (var type in types)
            {
                BaseInteraction item = (BaseInteraction)Activator.CreateInstance(type);
                all_interactions.Add(item);
            }
        }

        public List<IInteractionType> GetAllOf<IInteractionType>()
        {
            return InteractionsCache<IInteractionType>.GetAllOf(this);
        }
    }

    public static class InteractionsCache<IInteractionType>
    {
        public static List<IInteractionType> all;
        public static List<IInteractionType> GetAllOf(InteractionsManager interactionManager)
        {
            if (all != null)
            {
                return all;
            }

            all = new List<IInteractionType>(64);

            foreach (var interaction in interactionManager.all_interactions)
            {
                if (interaction is IInteractionType t)
                {
                    all.Add(t);
                }
            }
            all.Sort((a, b) => (b as BaseInteraction).Priority() - (a as BaseInteraction).Priority());
            return all;
        }
    }
}
