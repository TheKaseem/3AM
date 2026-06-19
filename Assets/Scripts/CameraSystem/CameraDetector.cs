using UnityEngine;

public class CameraDetector : MonoBehaviour
{
    [Header("Settings")]
    public float camDetectionRange = 10f;
    public float visionAngle = 45f;
    public GameObject savingGO;

    public string[] detectableTags = { "Enemy", "Shadow", "Translucent", "ParanormalEvent" };

    private void Update()
    {
        bool detected = false;

        foreach (string tag in detectableTags)
        {
            GameObject target = GameObject.FindGameObjectWithTag(tag);
            if (target == null) continue;

            Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, target.transform.position);
            float angle = Vector3.Angle(transform.forward, dirToTarget);

            if (distance <= camDetectionRange && angle <= visionAngle)
            {
                detected = true;
                break;
            }
        }

        if (detected)
        {
            if (!savingGO.activeSelf)
            {
                savingGO.SetActive(true);
            }
        }
        else
        {
            if (savingGO.activeSelf)
            {
                savingGO.SetActive(false);
            }
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
