using UnityEngine;

public class TraslucidEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Si el objeto que chocó tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Desactiva este objeto
            gameObject.SetActive(false);
        }
    }
}
