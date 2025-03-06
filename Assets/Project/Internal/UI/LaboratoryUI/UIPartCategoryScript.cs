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

        [HideInInspector] public List<GameObject> CategoryItems;


        public Transform GetCategoryTransform()
        {
            if (ItemsContainer != null)
                return ItemsContainer;

            Debug.Log($"Items container wasn't specified in Monster part category of {PartType} type");
            return null;
        }
    }
}
