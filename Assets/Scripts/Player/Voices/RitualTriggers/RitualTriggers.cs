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
        if (riceObject != null) riceObject.SetActive(false);
        if (ritualStart != null) ritualStart.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!knifeTriggered && other.CompareTag("Knife") && gameObject.CompareTag("Doll"))
        {
            Transform dollModel = transform.Find("DollOG");
            if (dollModel != null) Destroy(dollModel.gameObject);

            GameObject skinny = Instantiate(dollSkinnyPrefab, transform);
            skinny.transform.localPosition = Vector3.zero;
            skinny.transform.localRotation = Quaternion.identity;

            PlaySound(dialogueFour);
            knifeTriggered = true;
            if (riceObject != null) riceObject.SetActive(true);
        }

        if (knifeTriggered && !riceTriggered && other.CompareTag("Rice"))
        {
            Transform skinnyModel = transform.Find(dollSkinnyPrefab.name + "(Clone)");
            if (skinnyModel != null) Destroy(skinnyModel.gameObject);

            GameObject fat = Instantiate(dollFatPrefab, transform);
            fat.transform.localPosition = Vector3.zero;
            fat.transform.localRotation = Quaternion.identity;

            PlaySound(dialogueFive);
            riceTriggered = true;
            if (ritualStart != null) ritualStart.SetActive(true);
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
