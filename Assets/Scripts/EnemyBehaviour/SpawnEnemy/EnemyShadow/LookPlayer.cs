using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class LookPlayer : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        // Busca automáticamente al objeto con la etiqueta "Player"
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
       
    }

    void Update()
    {
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = player.position - transform.position;

            // Ignora la rotación en X y Z (solo rota en Y)
            direction.y = 0;

            // Si la dirección no es cero, rota hacia el jugador
            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = rotation;
            }
        }
    }


}
