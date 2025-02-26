using Internal.MonsterPartSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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
    }

    public class MonsterPartsRegistry : MonoBehaviour
    {
        [SerializeField] public PartRegistry<MonsterLeg> Legs;
        [SerializeField] public PartRegistry<MonsterArm> Arms;
        [SerializeField] public PartRegistry<MonsterBody> Bodies;
        [SerializeField] public PartRegistry<MonsterHead> Heads;

        private static MonsterPartsRegistry _instance;

        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
            }
        }
        public static MonsterPartsRegistry Instance()
        {
            return _instance;
        }

    }
}
