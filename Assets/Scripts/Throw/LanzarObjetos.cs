using UnityEngine;
using System.Collections;

public class LanzarObjetos : MonoBehaviour
{
    [Header("Configuración")]
    public GameObject[] objetos;        // Los objetos a lanzar 
    public float tiempoEspera = 3f;     // Tiempo antes de iniciar la secuencia
    public Vector3 direccion = Vector3.forward; // Dirección del lanzamiento
    public float fuerza = 10f;          // Fuerza del lanzamiento
    public float intervalo = 2f;        // Tiempo entre cada lanzamiento
    public float tiempoDesactivar = 2f; // Tiempo después de lanzados para desactivarlos
    public AudioClip sonidoImpacto;     // Sonido al caer

    private void Start()
    {
        // Inicia la secuencia después del tiempo de espera
        Invoke("IniciarSecuencia", tiempoEspera);
    }

    void IniciarSecuencia()
    {
        StartCoroutine(LanzarUnoPorUno());
    }

    IEnumerator LanzarUnoPorUno()
    {
        foreach (GameObject obj in objetos)
        {
            if (obj != null)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(direccion.normalized * fuerza, ForceMode.Impulse);
                }

                // Aseguramos que cada objeto tenga el script de sonido
                if (obj.GetComponent<SonidoAlCaer>() == null)
                {
                    SonidoAlCaer s = obj.AddComponent<SonidoAlCaer>();
                    s.sonidoImpacto = sonidoImpacto;
                }

                // Desactivar después de cierto tiempo
                StartCoroutine(DesactivarObjeto(obj));
            }

            // Espera antes de lanzar el siguiente objeto
            yield return new WaitForSeconds(intervalo);
        }
    }

    IEnumerator DesactivarObjeto(GameObject obj)
    {
        yield return new WaitForSeconds(tiempoDesactivar);
        obj.SetActive(false);
    }
}

// Script auxiliar para reproducir sonido al caer
public class SonidoAlCaer : MonoBehaviour
{
    public AudioClip sonidoImpacto;
    private bool yaSono = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!yaSono && sonidoImpacto != null)
        {
            AudioSource.PlayClipAtPoint(sonidoImpacto, transform.position);
            yaSono = true;
        }
    }
}
