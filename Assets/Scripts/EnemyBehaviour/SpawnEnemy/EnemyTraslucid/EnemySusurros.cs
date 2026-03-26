using UnityEngine;

public class EnemySusurros : MonoBehaviour
{
    public AudioSource audioSource; // Asigna el AudioSource en el inspector
    public float detectionRange = 5f; // Rango de detección

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Busca todos los enemigos con el tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        bool isNearEnemy = false;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(player.transform.position, enemy.transform.position);

            if (distance <= detectionRange)
            {
                isNearEnemy = true;
                break;
            }
        }

        if (isNearEnemy && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (!isNearEnemy && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
