using UnityEngine;

public class CasetteTrigger : MonoBehaviour
{
    [Header("Audio Settings")]
    public GameObject recorderVoice;
    public AudioClip cassetteSound;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Cassette") && gameObject.CompareTag("Recorder"))
        {
            AudioSource audioSource = recorderVoice.GetComponent<AudioSource>();
            if (audioSource != null && cassetteSound != null)
            {
                audioSource.PlayOneShot(cassetteSound);
                hasPlayed = true;
            }

            Destroy(other.gameObject);
        }
    }
}
