using UnityEngine;

public class RaycastPlayer : MonoBehaviour
{
    [Header("Raycast")]
    public float detectionRange = 10f;

    [Header("Movimiento enemigo")]
    public float chaseSpeed = 3f;

    void Update()
    {
        // Lanzamos raycast desde el jugador hacia adelante
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionRange))
        {
            // Si golpea un objeto con tag y layer Enemy
            if (hit.collider.CompareTag("Shadow"))
            {
                EnemyShadow enemy = hit.collider.GetComponent<EnemyShadow>();
                if (enemy != null)
                {
                    enemy.IncreaseCounter(); // sube el contador
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * detectionRange);
    }
}
