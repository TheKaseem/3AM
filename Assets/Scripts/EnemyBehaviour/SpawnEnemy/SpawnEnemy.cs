using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Prefab a spawnear")]
    public GameObject objetoPrefab;

    [Header("Tiempo de vida (segundos)")]
    public float tiempoDeVida = 5f;

    private GameObject objetoInstanciado;

    void Start()
    {
        // Instancia el objeto inmediatamente
        objetoInstanciado = Instantiate(objetoPrefab, transform.position, transform.rotation);

        // Lo desactiva después del tiempo indicado
        Invoke(nameof(DesactivarObjeto), tiempoDeVida);
    }

    void DesactivarObjeto()
    {
        if (objetoInstanciado != null)
        {
            objetoInstanciado.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (objetoInstanciado != null && other.CompareTag("Player"))
        {
            objetoInstanciado.SetActive(false);
        }
    }
}
