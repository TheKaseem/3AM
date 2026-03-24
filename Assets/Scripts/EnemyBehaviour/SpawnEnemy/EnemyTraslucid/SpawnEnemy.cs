using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("EnemyPrefab")]
    public GameObject enemyPrefab;

    [Header("Time")]
    public float timeLife = 5;

    //[Header("Audio")]
    //public AudioClip disappearSound; // arrastra tu clip aquí en el inspector
    //private AudioSource audioSource;

    private GameObject instanceObject;

    void Start()
    {
        // Añadimos un AudioSource al objeto que tiene este script
        //audioSource = gameObject.AddComponent<AudioSource>();

        instanceObject = Instantiate(enemyPrefab, transform.position, transform.rotation);

        // Se desactiva después de cierto tiempo
        StartCoroutine(DesactivatePostTime(instanceObject, timeLife));
    }

    private System.Collections.IEnumerator DesactivatePostTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        if (obj != null)
        {
            obj.SetActive(false);
            //PlayDisappearSound();
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (instanceObject != null && other.CompareTag("Player"))
        {
            instanceObject.SetActive(false);
            //PlayDisappearSound();
        }
    }*/

    /*
    private void PlayDisappearSound()
    {
        if (disappearSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(disappearSound);
        }
    }
    */
}
