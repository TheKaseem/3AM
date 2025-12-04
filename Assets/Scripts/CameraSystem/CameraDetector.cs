using UnityEngine;

public class CameraDetector : MonoBehaviour
{
    [Header("Settings")]
    public float camDetectionRange = 10f;
    public float visionAngle = 45f;
    public GameObject savingGO;
    public string tag;

    private void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag(tag);

        Vector3 dirToEnemy = (enemy.transform.position - transform.position).normalized;

        float distance = Vector3.Distance(transform.position, enemy.transform.position);
        float angle = Vector3.Angle(transform.forward, dirToEnemy);

        if (distance <= camDetectionRange && angle <= visionAngle)
        {
            if (!savingGO.activeSelf)
            {
                savingGO.SetActive(true);
            }
            return;
        }

        if (savingGO.activeSelf)
        {
            savingGO.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, camDetectionRange);

        Vector3 leftBoundary = Quaternion.Euler(0, -visionAngle, 0) * transform.forward;
        Vector3 rightBoundary = Quaternion.Euler(0, visionAngle, 0) * transform.forward;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, leftBoundary * camDetectionRange);
        Gizmos.DrawRay(transform.position, rightBoundary * camDetectionRange);
    }
}