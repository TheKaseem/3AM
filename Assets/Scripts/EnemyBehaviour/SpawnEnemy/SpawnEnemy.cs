using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("EnemyPrefab")]
    public GameObject enemyPrefab;

    [Header("Time")]
    public float timeLife = 5;

    private GameObject instanceObject;

    void Start()
    {
        instanceObject = Instantiate(enemyPrefab, transform.position, transform.rotation);

        StartCoroutine(DesactivatePostTime(instanceObject, timeLife));
    }
    
    private System.Collections.IEnumerator DesactivatePostTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        if (obj != null)
        {
        obj.SetActive(false);
        }

    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (instanceObject != null && other.CompareTag("Player"))
        {
            instanceObject.SetActive(false);
        }
    }*/

}
