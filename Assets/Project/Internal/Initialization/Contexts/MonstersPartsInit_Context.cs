using System;
using System.Collections;
using System.Collections.Generic;
using Internal.GameStatics;
using UnityEngine;

namespace Internal.GameInitialization.Contexts
{


    [Serializable]
    public class MonstersPartsInit_Context
    {
        [SerializeField] public MonsterPartsRegistry MonsterPartsRegistry;

        public void CacheMonsterPartsRegistry()
        {
            if (MonsterPartsRegistry == null)
            {
                Debug.LogError("Monster Parts Registry was null!");
                return;
            }

            MonsterPartsRegistryCache.CacheRegistry(MonsterPartsRegistry);
        }
    }
}
