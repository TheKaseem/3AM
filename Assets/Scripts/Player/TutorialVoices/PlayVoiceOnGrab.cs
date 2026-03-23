using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayVoiceOnGrab : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    [Header("Audio del evento")]
    public AudioClip grabClip;
    public AudioSource playerVoice;

    [SerializeField] private bool alreadyPlayed = false;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (!alreadyPlayed && playerVoice != null && grabClip != null)
        {
            playerVoice.clip = grabClip;
            playerVoice.Play();
            alreadyPlayed = true;
        }
    }
}
