using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneChange : MonoBehaviour
{
    [Header("Scene Settings")]
    public string scene;
    public string tag;
    public bool useLoadingScene = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        if (useLoadingScene)
        {
            SceneTransitionManager.nextSceneName = scene;
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }
}
