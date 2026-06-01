using UnityEngine;

[RequireComponent(typeof(Light))]
public class RaycastLight : MonoBehaviour
{
    public Transform target; 
    public float maxDistance = 10f; 

    private Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        if (target == null)
        {
            myLight.enabled = false;
            return;
        }

        Vector3 direction = Vector3.down; 
        RaycastHit hit;

        Color rayColor = Color.red;
        if (Physics.Raycast(transform.position, direction, out hit, maxDistance))
        {
            if (hit.transform == target)
            {
                rayColor = Color.green;
                myLight.enabled = true;
            }
            else
            {
                myLight.enabled = false;
            }
            Debug.DrawLine(transform.position, hit.point, rayColor);
        }
        else
        {
            myLight.enabled = false;
            Debug.DrawRay(transform.position, direction * maxDistance, rayColor);
        }
    }
}
