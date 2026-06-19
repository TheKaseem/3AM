using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ArribaMuñeco : MonoBehaviour
{
    public float velocidad = 5f;
    public float alturaMaxima = 10f;
    public float tiempoDesactivacion = 1.5f;
    public float tiempoEspera = 10f; 
    public AudioClip audioVuelo;

    private bool lanzado = false;
    private float alturaInicial;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        alturaInicial = transform.position.y;
        StartCoroutine(EsperarYLanzar());
    }

    IEnumerator EsperarYLanzar()
    {
        yield return new WaitForSeconds(tiempoEspera);
        Lanzar();
    }

    public void Lanzar()
    {
        if (!lanzado)
        {
            lanzado = true;
            if (audioVuelo != null)
            {
                audioSource.clip = audioVuelo;
                audioSource.Play();
            }
        }
    }

    void Update()
    {
        if (lanzado)
        {
            transform.position += Vector3.up * velocidad * Time.deltaTime;

            if (transform.position.y >= alturaInicial + alturaMaxima)
            {
                lanzado = false;
                StartCoroutine(DesactivarConRetraso());
            }
        }
    }

    IEnumerator DesactivarConRetraso()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        yield return new WaitForSeconds(tiempoDesactivacion);
        gameObject.SetActive(false);
    }
}
