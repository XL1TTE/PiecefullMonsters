using System.Collections;
using System.Collections.Generic;
using Internal.MonsterPartSystem;
using UnityEngine;

namespace Internal.LaboratoryUI
{
    public class UIPartCategoryScript : MonoBehaviour
    {
        public MonsterPartType PartType;

        [SerializeField] Transform ItemsContainer;


        public Transform GetCategoryTransform()
        {
            return ItemsContainer;
        }
    }
}
