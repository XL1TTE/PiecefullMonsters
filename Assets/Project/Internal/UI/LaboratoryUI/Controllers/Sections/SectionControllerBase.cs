using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.LaboratoryUI.Controllers
{
    public abstract class SectionControllerBase : MonoBehaviour
    {
        public abstract void EnableUIBehaviour();
        public abstract void DisableUIBehaviour();


        public abstract void Setup_UI();

    }
}
