using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Internal.Modifiers_System
{
    public class StatsMediator
    {
        readonly LinkedList<ModifierBase> modifiers = new();

        public event EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query query)
        {
            Queries?.Invoke(sender, query);
        }

        public void AddModifier(ModifierBase modifier)
        {
            modifiers.AddLast(modifier);
            Queries += modifier.Handle;

            modifier.OnMarkedForRemoval += RemoveMarkedModifier;

            modifier.OnDispose += _ =>
            {
                modifiers.Remove(modifier);
                Queries -= modifier.Handle;
            };
        }

        private void RemoveMarkedModifier(ModifierBase modifier)
        {
            modifier.Dispose();
        }

        public void RemoveModifier(ModifierBase modifier)
        {
            if (modifiers.Contains(modifier)) modifier.Dispose();
        }


        public void Update(float deltaTime)
        {

        }
    }


    public class Query
    {
        public readonly StatType AffectedStatType;
        public float Value;

        public Query(StatType statType, float value)
        {
            AffectedStatType = statType;
            Value = value;
        }
    }
}
