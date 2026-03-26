using UnityEngine;

public class RitualTriggers : MonoBehaviour
{
    [Header("Dolls Models")]
    public GameObject dollSkinnyPrefab;
    public GameObject dollFatPrefab;

    [Header("Recorder Voice")]
    public GameObject recorderVoice;
    public AudioClip dialogueFour;
    public AudioClip dialogueFive;

    [Header("Post Event Objects")]
    public GameObject riceObject;
    public GameObject ritualStart;

    private bool knifeTriggered = false;
    private bool riceTriggered = false;

    void Start()
    {
        riceObject.SetActive(false);
        ritualStart.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!knifeTriggered && other.CompareTag("Knife") && gameObject.CompareTag("Doll"))
        {
            Vector3 currentPosition = transform.position;
            Quaternion currentRotation = transform.rotation;

            Destroy(gameObject);

            GameObject skinny = Instantiate(dollSkinnyPrefab, currentPosition, currentRotation);
            PlaySound(dialogueFour);
            knifeTriggered = true;
            riceObject.SetActive(true);

            RitualTriggers skinnyScript = skinny.AddComponent<RitualTriggers>();
            skinnyScript.dollSkinnyPrefab = dollSkinnyPrefab;
            skinnyScript.dollFatPrefab = dollFatPrefab;
            skinnyScript.recorderVoice = recorderVoice;
            skinnyScript.dialogueFour = dialogueFour;
            skinnyScript.dialogueFive = dialogueFive;
            skinnyScript.riceObject = riceObject;
            skinnyScript.knifeTriggered = true;
        }

        if (knifeTriggered && !riceTriggered && other.CompareTag("Rice"))
        {
            Vector3 currentPosition = transform.position;
            Quaternion currentRotation = transform.rotation;

            Destroy(gameObject);

            Instantiate(dollFatPrefab, currentPosition, currentRotation);
            PlaySound(dialogueFive);
            riceTriggered = true;
            ritualStart.SetActive(true);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        AudioSource audioSource = recorderVoice.GetComponent<AudioSource>();
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
