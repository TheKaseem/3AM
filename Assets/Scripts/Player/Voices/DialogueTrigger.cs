using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Event Audio")]
    public AudioClip voiceClip;
    public AudioSource playerVoice;
    [SerializeField] private bool alreadyPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlayed && other.CompareTag("Player"))
        {
            if (playerVoice != null && voiceClip != null)
            {
                playerVoice.clip = voiceClip;
                playerVoice.Play();
                alreadyPlayed = true;
            }
        }
    }
}
