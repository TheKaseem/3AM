using UnityEngine;

public class EnemyShadow : MonoBehaviour
{
    [Header("Contador")]
    public float contador = 65f;
    public float maxContador = 100f;
    public float deactivateEnemy = 15f;
    public float increaseRange = 1f;
    public float decreaseRange = 1f;

    [Header("Movimiento")]
    public Transform player;
    public float chaseSpeed = 3f;
    private bool isChasing = false;

    private bool touchedByRaycast = false; // flag para saber si fue tocado este frame

    void Update()
    {
        if(touchedByRaycast)
        {
            contador = Mathf.Min(contador + increaseRange * Time.deltaTime, maxContador);
        }
        else
        {
            contador = Mathf.Max(contador - decreaseRange * Time.deltaTime, 0f);
        }

        touchedByRaycast = false;

        // Si contador llega a 100, perseguir
        if (contador >= maxContador)
        {
            isChasing = true;
        }

        // Si contador baja de 50, desactivar enemigo
        if (contador <= deactivateEnemy)
        {
            gameObject.SetActive(false);
        }

        // Movimiento de persecución
        if (isChasing && player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        }
    }

    public void IncreaseCounter()
    {
        touchedByRaycast = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Al chocar con el jugador, se desactiva
            gameObject.SetActive(false);
        }
    }
}
