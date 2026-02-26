using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeLife = 5;

    private GameObject instanceObject;

    void Start()
    {
        instanceObject = Instantiate(enemyPrefab, transform.position, transform.rotation);

        //StartCoroutine(DesactivatePostTime(instanceObject, timeLife));
    }
    /*
    private System.Collections.IEnumerator DesactivatePostTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        if (obj != null)
        {
        obj.SetActive(false);
        }

    }*/
    
}
