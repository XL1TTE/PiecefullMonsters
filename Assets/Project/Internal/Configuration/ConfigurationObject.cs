using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal
{
    public class ConfigurationObject : MonoBehaviour
    {
        [SerializeField] string AfterConfigureSceneName;
        [SerializeField] string SceneTransitionTemplateID;

        private void Awake()
        {
            StartCoroutine(ConfigurationProgressCheckCoroutine());
        }

        private void OnDestroy()
        {
            StopCoroutine(ConfigurationProgressCheckCoroutine());
        }
        private IEnumerator ConfigurationProgressCheckCoroutine()
        {
            while(this.gameObject.transform.childCount != 0)
            {
                yield return null;
            }
            ScenesTransitionManager.ST_SingleMode_WithLoadingScreenAsync(AfterConfigureSceneName, SceneTransitionTemplateID);
        }
    }
}
