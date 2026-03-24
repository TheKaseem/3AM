using UnityEngine;
using UnityEngine.Audio;

public class TraslucidEnemy : MonoBehaviour
{
    [Header("Audio")]
    private AudioSource audioSource;

    public AudioClip disappearSound;
    

    private void Start()
    {
        //audiosource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que chocó tiene la etiqueta "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            
            //SoundControllerEnemy.Instance.playSound(disappearSound);
            AudioSource.PlayClipAtPoint(disappearSound, Camera.main.transform.position);

            gameObject.SetActive(false);
        }
    }
    
}
