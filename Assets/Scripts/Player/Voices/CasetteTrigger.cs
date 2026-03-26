using UnityEngine;

public class CasetteTrigger : MonoBehaviour
{
    [Header("Audio Settings")]
    public GameObject recorderVoice;
    public AudioClip cassetteSound;

    [Header("Object Post Event")]
    public GameObject doll;

    private bool hasPlayed = false;


    void Start()
    {
        doll.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Cassette") && gameObject.CompareTag("Recorder"))
        {
            AudioSource audioSource = recorderVoice.GetComponent<AudioSource>();
            if (audioSource != null && cassetteSound != null)
            {
                audioSource.PlayOneShot(cassetteSound);
                hasPlayed = true;
                doll.SetActive(true);
            }

            Destroy(other.gameObject);
        }
    }
}
