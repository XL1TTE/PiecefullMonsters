using Internal.MonsterPartSystem;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Internal.GameStatics
{
    [Serializable]
    public class MonsterPart_ID_Pair
    {
        public string ID;
        public SO_MonsterPartBase_Factory MonsterPart_Factory;
    }

    [Serializable]
    public class PartRegistry
    {
        [SerializeField]
        private List<MonsterPart_ID_Pair> Registry = new();

        public SO_MonsterPartBase_Factory GetByID(string ID)
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
        [SerializeField] public PartRegistry Parts = new();


        public List<string> GetAllIDs()
        {

            return Parts.GetAllIDs();
        }

        public SO_MonsterPartBase_Factory GetByID(string id)
        {
            return Parts.GetByID(id);
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

        public static SO_MonsterPartBase_Factory GetByID(string id)
        {
            return Registry.GetByID(id);
        }

    }
}
