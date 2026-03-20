using UnityEngine;

public class SoundControllerEnemy : MonoBehaviour
{

    public static SoundControllerEnemy Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if(Instance = null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else 
        {
            Destroy(gameObject);        
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void playSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
