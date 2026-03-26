using UnityEngine;

public class Dialogo2Event : MonoBehaviour
{
    [Header("Flickering Lights")]
    public Light[] lights;
    public float flickerDuration = 2f;
    public float flickerSpeed = 0.1f;

    [SerializeField] private bool alreadyTriggered = false;

    [Header("Gravity")]
    public GameObject casette;

    [Header("Audios (Clips)")]
    public AudioClip flickingLightsClip;
    public AudioClip fallenCasetteClip;

    [Header("Audio Source del Player")]
    public AudioSource playerVoice;

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyTriggered && other.CompareTag("Player"))
        {
            alreadyTriggered = true;

            Rigidbody rb = casette.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
            }

            if (playerVoice != null && flickingLightsClip != null)
                playerVoice.PlayOneShot(flickingLightsClip);

            if (playerVoice != null && fallenCasetteClip != null)
                playerVoice.PlayOneShot(fallenCasetteClip);

            StartCoroutine(FlickerLights());
        }
    }

    private System.Collections.IEnumerator FlickerLights()
    {
        float elapsed = 0f;
        while (elapsed < flickerDuration)
        {
            foreach (Light l in lights)
            {
                if (l != null)
                    l.enabled = !l.enabled;
            }
            yield return new WaitForSeconds(flickerSpeed);
            elapsed += flickerSpeed;
        }

        foreach (Light l in lights)
        {
            if (l != null)
                l.enabled = true;
        }
    }
}
