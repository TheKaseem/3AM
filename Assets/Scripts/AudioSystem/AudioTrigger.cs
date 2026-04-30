using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
                hasPlayed = true;
            }
        }
    }
}
