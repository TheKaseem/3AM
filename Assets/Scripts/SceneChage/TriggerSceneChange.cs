using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneChange : MonoBehaviour
{
    [Header("Scene Settings")]
    public string scene;
    public string tag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
