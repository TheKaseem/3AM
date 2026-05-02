using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SimpleAnimation : MonoBehaviour
{
    [Header("Scene Name")]
    public string sceneName;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    [Header("Animación hacia el jugador")]
    public Transform objeto;          
    public Transform destinoJugador; 
    public float duracion = 2f;       

    public void StartAudio()
    {
        Debug.Log("Botón StartTutorial fue presionado");
        StartCoroutine(PlaySoundAnimate());
    }

    private IEnumerator PlaySoundAnimate()
    {

        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            yield return new WaitForSeconds(clickSound.length);
        }


        Vector3 inicio = objeto.position;
        float tiempoInicio = Time.time;

        while (Time.time - tiempoInicio < duracion)
        {
            float t = (Time.time - tiempoInicio) / duracion;
            objeto.position = Vector3.Lerp(inicio, destinoJugador.position, t);
            yield return null;
        }


        objeto.position = destinoJugador.position;
        Debug.Log("Animación completada, cargando escena: " + sceneName);


        SceneManager.LoadScene(sceneName);
    }
}
