using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyTraslucent : MonoBehaviour
{
    [Header("EnemyPrefab")]
    public GameObject enemyPrefab;

    [Header("Time")]
    public float timeLife = 5;


    [Header("Posiciones de spawn")]
    public Transform[] spawnPoints; // posiciones de los spawns

    [Header("Tiempo de spawn")]
    public float spawnInterval = 3f; // cada cuanto aparece un enemy

    private List<Transform> availablePositions = new List<Transform>();


    //[Header("Audio")]
    //public AudioClip disappearSound; 
    //private AudioSource audioSource;

    private GameObject instanceObject;

    void Start()
    {

        //audioSource = gameObject.AddComponent<AudioSource>();
        availablePositions.AddRange(spawnPoints);

        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);

        instanceObject = Instantiate(enemyPrefab, transform.position, transform.rotation);

        StartCoroutine(DesactivatePostTime(instanceObject, timeLife));
    }

    private System.Collections.IEnumerator DesactivatePostTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        if (obj != null)
        {
            obj.SetActive(false);
            //PlayDisappearSound();
        }
    }
    void SpawnEnemy()
    {
        if (availablePositions.Count == 0) // si ya no cuentra sopawns diaponibles se detiene el spawner
        {

            CancelInvoke(nameof(SpawnEnemy));
            return;
        }

        // Elegimos una posición aleatoria de las disponibles
        int randomIndex = Random.Range(0, availablePositions.Count);
        Transform chosenPoint = availablePositions[randomIndex];

        // Instanciamos el enemigo en esa posición
        Instantiate(enemyPrefab, chosenPoint.position, chosenPoint.rotation);

        // Eliminamos esa posición de la lista para no volver a usarla
        availablePositions.RemoveAt(randomIndex);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (instanceObject != null && other.CompareTag("Player"))
        {
            instanceObject.SetActive(false);
            //PlayDisappearSound();
        }
    }*/

    /*
    private void PlayDisappearSound()
    {
        if (disappearSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(disappearSound);
        }
    }
    */
}
