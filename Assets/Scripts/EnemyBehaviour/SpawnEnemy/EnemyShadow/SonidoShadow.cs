using UnityEngine;

public class SonidoShadow : MonoBehaviour
{
    [Header("Audio")]
    private AudioSource audioSource;

    public AudioClip disappearSound;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

    }

    void Update()
    {
        
    }
}
