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
    private Transform player;       // ya no se asigna en el inspector
    public float chaseSpeed = 3f;
    private bool isChasing = false;

    private bool touchedByRaycast = false;

    void Start()
    {
        // Busca automáticamente el objeto con tag "Player"
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        LookPlayer();
    }

    void Update()
    {
        if (touchedByRaycast)
        {
            contador = Mathf.Min(contador + increaseRange * Time.deltaTime, maxContador);
        }
        else
        {
            contador = Mathf.Max(contador - decreaseRange * Time.deltaTime, 0f);
        }

        touchedByRaycast = false;

        if (contador >= maxContador)  // Si contador llega a 100 persigue a player
        {
            isChasing = true;
        }

        if (contador <= deactivateEnemy) // Si contador baja de 15 desactiva enemy
        {
            gameObject.SetActive(false);
        }

        if (isChasing && player != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                chaseSpeed * Time.deltaTime
            );
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
}
