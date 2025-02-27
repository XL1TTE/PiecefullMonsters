using Internal.MonsterPartSystem;
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Internal.GameStatics
{
    [Serializable]
    public class MonsterPart_ID_Pair<MonsterPartType>
    {
        public string ID;
        public SO_MonsterPartBase_Factory<MonsterPartType> MonsterPart_Factory;
    }

    [Serializable]
    public class PartRegistry<PartType>
    {
        [SerializeField]
        private List<MonsterPart_ID_Pair<PartType>> Registry = new();

        public SO_MonsterPartBase_Factory<PartType> GetByID(string ID)
        {
            var Record = Registry.Find(o => o.ID == ID);

            return Record.MonsterPart_Factory;
        }
        public List<string> GetAllIDs()
        {
            List<string> result = new();
            foreach (var record in Registry)
            {
                result.Add(record.ID);
            }
            return result;
        }
    }

    [Serializable]
    public class MonsterPartsRegistry
    {
        [SerializeField] public PartRegistry<MonsterLeg> Legs = new();
        [SerializeField] public PartRegistry<MonsterArm> Arms = new();
        [SerializeField] public PartRegistry<MonsterBody> Bodies = new();
        [SerializeField] public PartRegistry<MonsterHead> Heads = new();


        public List<string> GetAllIDs()
        {
            List<string> result = new();

            result.AddRange(Legs.GetAllIDs());
            result.AddRange(Arms.GetAllIDs());
            result.AddRange(Bodies.GetAllIDs());
            result.AddRange(Heads.GetAllIDs());

            return result;
        }
    }

    public static class MonsterPartsRegistryCache
    {
        private static MonsterPartsRegistry Registry;

        public static void CacheRegistry(MonsterPartsRegistry registry)
        {
            Registry = registry;
        }

        public static List<string> GetAllIDs()
        {
            return Registry.GetAllIDs();
        }

        public static PartRegistry<MonsterLeg> Legs()
        {
            return Registry.Legs;
        }

        public static PartRegistry<MonsterArm> Arms()
        {
            return Registry.Arms;
        }

        public static PartRegistry<MonsterHead> Heads()
        {
            return Registry.Heads;
        }

        public static PartRegistry<MonsterBody> Bodies()
        {
            return Registry.Bodies;
        }

    }
}
