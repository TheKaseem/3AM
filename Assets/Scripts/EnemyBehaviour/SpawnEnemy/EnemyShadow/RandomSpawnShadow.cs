using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnShadow : MonoBehaviour
{
    [Header("Prefab del enemigo")]
    public GameObject enemyPrefab;

    [Header("Posiciones de spawn")]
    public Transform[] spawnPoints; // posiciones de los spawns

    [Header("Tiempo de spawn")]
    public float spawnInterval = 3f; // cada cuanto aparece un enemy

    private List<Transform> availablePositions = new List<Transform>();

    void Start()
    {
        availablePositions.AddRange(spawnPoints);

        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
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
}
