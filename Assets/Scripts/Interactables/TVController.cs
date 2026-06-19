using UnityEngine;
using System.Collections;

public class TVController : MonoBehaviour
{
    [Header("TV Settings")]
    public GameObject staticGO;
    public AudioSource tvAudioSource;
    public AudioClip staticSound;

    [Header("Probability Settings")]
    [Range(0f, 1f)]
    public float chanceToTurnOn = 0.5f;
    public float probabilityDistance = 10f;
    public float forcedEventDistance = 3f;

    [Header("Player")]
    public string playerTag = "Player";

    [Header("Enemy Spawner Reference")]
    public EnemySpawner enemySpawner;

    [Header("Cooldown Settings")]
    public float cooldownTime = 16f;

    private bool isOn = false;
    private bool isOnCooldown = false;

    void Start()
    {
        if (staticGO != null)
        {
            staticGO.SetActive(false);
        }
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player == null) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (GlobalEventManager.EventActive) return;

        if (!isOn && !isOnCooldown && distance <= probabilityDistance && distance > forcedEventDistance)
        {
            if (Random.value <= chanceToTurnOn)
            {
                TurnOnTV();
            }
        }

        if (distance <= forcedEventDistance)
        {
            TriggerParanormalEvent();
        }
    }

    void TurnOnTV()
    {
        if (GlobalEventManager.EventActive) return;

        isOn = true;
        if (staticGO != null)
        {
            staticGO.SetActive(true);
        }

        if (tvAudioSource != null && staticSound != null)
        {
            tvAudioSource.PlayOneShot(staticSound);
        }

        Debug.Log("La TV se encendió con estática: " + gameObject.name);
    }

    void TriggerParanormalEvent()
    {
        if (isOn && !GlobalEventManager.EventActive)
        {
            isOn = false;
            GlobalEventManager.EventActive = true;

            if (staticGO != null)
            {
                staticGO.SetActive(false);
            }

            Debug.Log("Evento paranormal ejecutado por: " + gameObject.name);

            if (enemySpawner != null)
            {
                enemySpawner.SpawnEnemy();
            }

            StartCoroutine(CooldownRoutine());
        }
    }

    private IEnumerator CooldownRoutine()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;

        GlobalEventManager.EventActive = false;

        Debug.Log("La TV puede volver a encenderse.");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, probabilityDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, forcedEventDistance);
    }
}
