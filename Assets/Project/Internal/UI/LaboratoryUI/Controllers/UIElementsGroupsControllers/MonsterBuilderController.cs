
using System.Collections;
using Internal.UI.EventSystem;
using Internal.UI.Utility;
using UnityEngine;

namespace Internal.LaboratoryUI.Controllers
{

    public class MonsterBuilderController : MonoBehaviour
    {
        [SerializeField] public MonsterBuilderSlotsEventsHandler BuiderSlotsEvents;

        public IEnumerator Setup()
        {
            Debug.Log("Setup Monster Builder");
            yield return null;
        }
    }
}
