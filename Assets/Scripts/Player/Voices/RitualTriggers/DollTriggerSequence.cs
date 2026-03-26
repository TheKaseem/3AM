using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DollTriggerSequence : MonoBehaviour
{
    [Header("Puerta")]
    public GameObject puerta;
    public Vector3 rotationAxis = Vector3.up;
    public float rotationDegrees = 90f;
    public float rotationDuration = 2f;
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
        if (puerta != null)
        {
            Quaternion startRot = puerta.transform.localRotation;
            Quaternion endRot = startRot * Quaternion.AngleAxis(rotationDegrees, rotationAxis);
            float t = 0;
            if (puertaAudio != null) puertaAudio.PlayOneShot(puertaAudio.clip);
            while (t < rotationDuration)
            {
                t += Time.deltaTime;
                puerta.transform.localRotation = Quaternion.Slerp(startRot, endRot, t / rotationDuration);
                yield return null;
            }
        }



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
