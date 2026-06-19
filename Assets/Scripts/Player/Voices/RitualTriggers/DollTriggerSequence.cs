using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DollTriggerSequence : MonoBehaviour
{
    [Header("Puertas")]
    public GameObject door1;
    public GameObject doorSlamed;
    public AudioSource puertaAudio;

    [Header("Luces")]
    public Light[] luces;
    public float flickerDuration = 15f;
    public float flickerInterval = 0.2f;
    public AudioSource lucesAudio;

    [Header("Grabadora")]
    public Transform recorderVoice;
    public Transform targetPosition;
    public float moveDuration = 15f;
    public AudioSource recorderVoiceAudio;
    public AudioClip DialogoSixSeven;

    [Header("Escenas")]
    public string loadingScene = "LoadingScene";
    public string nextScene = "NextScene";

    private bool triggered = false;

    void Start()
    {
        if (door1 != null) door1.SetActive(true);
        if (doorSlamed != null) doorSlamed.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Doll"))
        {
            triggered = true;
            StartCoroutine(Sequence());
        }
    }

    private IEnumerator Sequence()
    {
        if (door1 != null) door1.SetActive(false);
        if (doorSlamed != null) doorSlamed.SetActive(true);

        if (puertaAudio != null) puertaAudio.PlayOneShot(puertaAudio.clip);

        if (luces != null && luces.Length > 0)
        {
            StartCoroutine(FlickerLights());
        }

        if (recorderVoiceAudio != null && DialogoSixSeven != null)
        {
            recorderVoiceAudio.clip = DialogoSixSeven;
            recorderVoiceAudio.Play();
        }
        if (recorderVoice != null && targetPosition != null)
        {
            StartCoroutine(MoveRecorder());
        }

        float waitTime = (DialogoSixSeven != null ? DialogoSixSeven.length + 2f : 17f);
        yield return new WaitForSeconds(waitTime);

        SceneTransitionManager.nextSceneName = nextScene;
        SceneManager.LoadScene(loadingScene);
    }

    private IEnumerator FlickerLights()
    {
        if (lucesAudio != null) lucesAudio.Play();
        float elapsed = 0;
        while (elapsed < flickerDuration)
        {
            foreach (Light l in luces)
            {
                l.enabled = !l.enabled;
            }
            yield return new WaitForSeconds(flickerInterval);
            elapsed += flickerInterval;
        }
        foreach (Light l in luces) l.enabled = true;
    }

    private IEnumerator MoveRecorder()
    {
        Vector3 startPos = recorderVoice.position;
        float t = 0;
        while (t < moveDuration)
        {
            t += Time.deltaTime;
            recorderVoice.position = Vector3.Lerp(startPos, targetPosition.position, t / moveDuration);
            yield return null;
        }
    }
}
