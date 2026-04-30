using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class TraslucidEnemy : MonoBehaviour
{
    [Header("Audio")]
    private AudioSource audioSource;

    public AudioClip disappearSound;

    [Header("LookAt Player")]
    public Transform player;

    public float desactivateTime = 5f;

    private void Start()
    {
        //audiosource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();

        LookPlayer();

        Invoke(nameof(DisableEnemy), desactivateTime);
    }

    private void Update()
    {
        if(player != null)
        {
            Vector3 direccion = player.position - transform.position;
            direccion.y = 0; // evita que se incline en el eje vertical
            transform.rotation = Quaternion.LookRotation(direccion);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            //SoundControllerEnemy.Instance.playSound(disappearSound);
            AudioSource.PlayClipAtPoint(disappearSound, Camera.main.transform.position);

            gameObject.SetActive(false);
        }
    }

    void LookPlayer()
    {
        transform.LookAt(player);

        // Busca al objeto con el tag "Player" en la escena
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

    }

    void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
