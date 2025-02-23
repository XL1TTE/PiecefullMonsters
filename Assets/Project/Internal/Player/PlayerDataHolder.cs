using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Player
{
    public class PlayerDataHolder : MonoBehaviour
    {
        PlayerData PlayerData;

        private static PlayerDataHolder _instance;

        private void Awake()
        { 
            if( _instance == null)
            {
                _instance = this;
            }
        }

        public void SetPlayerData(PlayerData playerData)
        {
            PlayerData = playerData;
        }

        public static PlayerDataHolder Instance()
        {
            return _instance;
        }
    }
}
