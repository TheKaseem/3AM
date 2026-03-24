using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AmbientLoading : MonoBehaviour
{
    [Header("Tiempo mínimo de espera")]
    public float minWaitTime = 5f;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        string targetScene = SceneTransitionManager.nextSceneName;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene);
        asyncLoad.allowSceneActivation = false;

        float timer = 0f;

        while (!asyncLoad.isDone)
        {
            timer += Time.deltaTime;

            if (asyncLoad.progress >= 0.9f && timer >= minWaitTime)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
