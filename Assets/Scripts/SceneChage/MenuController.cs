using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [Header("Scene Target Data")]
    public string sceneName;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    public void StartTutorial()
    {
        StartCoroutine(PlaySoundAndLoad());
    }

    public void ExitGame()
    {
        if (audioSource != null && clickSound != null)
            audioSource.PlayOneShot(clickSound);

        Application.Quit();
    }

    private IEnumerator PlaySoundAndLoad()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            yield return new WaitForSeconds(clickSound.length);
        }

        SceneManager.LoadScene(sceneName);
    }
}
