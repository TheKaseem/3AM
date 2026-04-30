using UnityEngine;

public class CasetteTrigger : MonoBehaviour
{
    [Header("Triggers con Audio")]
    public GameObject disappearTrigger;
    public GameObject appearTrigger;

    [Header("Audio Settings")]
    public GameObject recorderVoice;
    public AudioClip cassetteSound;

    [Header("Objetos post evento")]
    public GameObject doll;
    public GameObject dollA;

    private bool cassettePlaced = false;

    void Start()
    {
        // Inician desactivados
        if (disappearTrigger != null) disappearTrigger.SetActive(false);
        if (appearTrigger != null) appearTrigger.SetActive(false);

        doll.SetActive(false);
        dollA.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!cassettePlaced && other.CompareTag("Cassette") && gameObject.CompareTag("Recorder"))
        {
            cassettePlaced = true;

            AudioSource audioSource = recorderVoice.GetComponent<AudioSource>();
            if (audioSource != null && cassetteSound != null)
            {
                audioSource.PlayOneShot(cassetteSound);
            }

            if (disappearTrigger != null) disappearTrigger.SetActive(true);
            if (appearTrigger != null) appearTrigger.SetActive(true);

            dollA.SetActive(false);
            doll.SetActive(true);

            Destroy(other.gameObject);
        }
    }
}
