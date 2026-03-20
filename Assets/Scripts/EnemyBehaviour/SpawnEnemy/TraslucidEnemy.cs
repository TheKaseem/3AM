using UnityEngine;

public class TraslucidEnemy : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip disappearSound; //clip se sonido de enemigo desaparecer

    private void OnCollisionEnter(Collision collision)
    {
        // Si el objeto que chocó tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
          
            SoundControllerEnemy.Instance.playSound(disappearSound);
            gameObject.SetActive(false);
        }
    }
}
