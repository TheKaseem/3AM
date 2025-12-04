using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 5f;
    public float minVolume = 0f;
    public float maxVolume = 1f; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = true;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        float t = Mathf.Clamp01(distance / maxDistance);

        float volume = Mathf.Lerp(maxVolume, minVolume, t);

        audioSource.volume = volume;
    }
}