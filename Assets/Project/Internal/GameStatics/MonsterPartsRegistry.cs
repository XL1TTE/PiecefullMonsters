using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Internal.GameStatics
{
    [Serializable]
    public class MonsterPart_ID_Pair
    {
        public string ID;
        public GameObject MonsterPart_Placeholder;
    } 

    public class MonsterPartsRegistry : MonoBehaviour
    {
        [SerializeField] private List<MonsterPart_ID_Pair> Registry = new();

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


        public GameObject GetMonsterPartFactoryByID(string ID)
        {
            var Record = Registry.Find(o => o.ID == ID);

            return Record.MonsterPart_Placeholder;
        }
    }
}
