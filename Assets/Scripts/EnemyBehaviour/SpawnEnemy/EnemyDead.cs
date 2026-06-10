using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDead : MonoBehaviour
{
    public string sceneName; // Nombre de la escena destino

    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos que este objeto tenga el tag "Vaso" y que el otro sea "Enemy"
        if (gameObject.CompareTag("Vaso") && collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Vaso") && other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
