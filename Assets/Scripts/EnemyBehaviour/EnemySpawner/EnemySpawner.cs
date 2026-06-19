using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public string playerTag = "Player";

    [Header("Timing Settings")]
    public float activeTime = 10f;

    [Header("Particle Settings")]
    public GameObject particlePrefab;
    public float smokeDuration = 6f;

    [Header("Audio Settings")]
    public AudioClip smokeSound;
    public AudioClip[] screamSounds;
    public AudioSource audioSource;

    private void Start()
    {
        if (enemyPrefab != null)
        {
            enemyPrefab.SetActive(false);
        }

        if (particlePrefab != null)
        {
            particlePrefab.SetActive(false);
        }
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0) return;

        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player == null) return;

        Transform closestSpawn = null;
        float minDistance = Mathf.Infinity;

        foreach (Transform sp in spawnPoints)
        {
            float dist = Vector3.Distance(player.transform.position, sp.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                closestSpawn = sp;
            }
        }

        if (closestSpawn != null)
        {
            StartCoroutine(SpawnWithSmoke(closestSpawn));
        }
    }

    private IEnumerator SpawnWithSmoke(Transform spawnPoint)
    {
        if (particlePrefab != null)
        {
            particlePrefab.transform.position = spawnPoint.position;
            particlePrefab.SetActive(true);

            ParticleSystem ps = particlePrefab.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }

            if (audioSource != null && smokeSound != null)
            {
                audioSource.PlayOneShot(smokeSound);
            }
        }

        yield return new WaitForSeconds(smokeDuration);

        enemyPrefab.transform.position = spawnPoint.position;
        enemyPrefab.transform.rotation = spawnPoint.rotation;
        enemyPrefab.SetActive(true);

        Debug.Log("Enemigo activado en: " + spawnPoint.name);


        if (audioSource != null && screamSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, screamSounds.Length);
            audioSource.PlayOneShot(screamSounds[randomIndex]);
        }

        StartCoroutine(DeactivateEnemyAfterTime());
    }

    private IEnumerator DeactivateEnemyAfterTime()
    {
        yield return new WaitForSeconds(activeTime);

        if (enemyPrefab != null)
        {
            enemyPrefab.SetActive(false);
            Debug.Log("Enemigo desactivado.");
        }

        if (particlePrefab != null)
        {
            particlePrefab.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        foreach (Transform sp in spawnPoints)
        {
            if (sp != null)
                Gizmos.DrawWireSphere(sp.position, 1f);
        }
    }
}