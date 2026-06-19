using UnityEngine;
using System.Collections;

public class PhoneController : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource phoneAudioSource;
    public AudioClip ringClip;

    [Header("Probability Settings")]
    [Range(0f, 1f)]
    public float chanceToTurnOff = 0.5f;
    public float probabilityDistance = 10f;
    public float forcedOffDistance = 3f;

    [Header("Player")]
    public string playerTag = "Player";

    [Header("Enemy Spawner Reference")]
    public EnemySpawner enemySpawner;

    [Header("Reactivation Settings")]
    public float reactivationTime = 15f;

    private bool isOn = false;

    void Start()
    {
        if (phoneAudioSource != null)
        {
            phoneAudioSource.Stop();
        }

        StartCoroutine(ReactivatePhoneAfterTime());
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player == null || phoneAudioSource == null) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (!isOn || GlobalEventManager.EventActive) return;

        if (distance <= probabilityDistance && distance > forcedOffDistance)
        {
            if (Random.value <= chanceToTurnOff)
            {
                TurnOffPhone();
            }
        }

        if (distance <= forcedOffDistance)
        {
            TurnOffPhone();
        }
    }

    void TurnOffPhone()
    {
        if (GlobalEventManager.EventActive) return;

        isOn = false;
        phoneAudioSource.Stop();
        Debug.Log("Telephone is off.");

        if (enemySpawner != null)
        {
            enemySpawner.SpawnEnemy();
        }

        GlobalEventManager.EventActive = true;

        StartCoroutine(ReactivatePhoneAfterTime());
    }

    private IEnumerator ReactivatePhoneAfterTime()
    {
        yield return new WaitForSeconds(reactivationTime);

        isOn = true;
        if (phoneAudioSource != null && ringClip != null)
        {
            phoneAudioSource.clip = ringClip;
            phoneAudioSource.loop = true;
            phoneAudioSource.Play();
        }


        GlobalEventManager.EventActive = false;

        Debug.Log("Telephone is on.");
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, probabilityDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, forcedOffDistance);
    }
}
