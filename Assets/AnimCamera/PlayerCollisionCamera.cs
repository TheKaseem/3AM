using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollisionCamera : MonoBehaviour
{
    public Animator cameraAnimator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(DeathSequence());
        }
    }

    IEnumerator DeathSequence()
    {
        // Activa la animación
        cameraAnimator.SetTrigger("DeathAnimation");

        // Espera hasta que el Animator esté en Recorded
        yield return new WaitUntil(() =>
            cameraAnimator.GetCurrentAnimatorStateInfo(0).IsName("Recorded"));

        // Obtén la duración del estado actual
        float clipLength = cameraAnimator.GetCurrentAnimatorStateInfo(0).length;

        // Espera esa duración completa
        yield return new WaitForSeconds(clipLength);

        // Cambia de escena
        SceneManager.LoadScene("DeathScene");
    }
}
