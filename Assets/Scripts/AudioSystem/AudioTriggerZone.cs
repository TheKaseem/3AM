using UnityEngine;

public class AudioTriggerZone : MonoBehaviour
{
    public enum ZoneType
    {
        Hallway,
        Hitorikakurenbo
    }

    [Header("Select Zone")]
    public ZoneType zoneType;

    [Header("Audio Sources")]
    public AudioSource hallwayAudio;
    public AudioSource hitorikakurenboAudio;

    private void Start()
    {
        if (hitorikakurenboAudio != null)
        {
            hitorikakurenboAudio.Stop();
            hitorikakurenboAudio.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayZoneAudio();
        }
    }

    private void PlayZoneAudio()
    {
        switch (zoneType)
        {
            case ZoneType.Hallway:
                if (hallwayAudio != null)
                {
                    if (hitorikakurenboAudio != null) hitorikakurenboAudio.Stop();
                    hallwayAudio.enabled = true;
                    hallwayAudio.Play();
                }
                break;

            case ZoneType.Hitorikakurenbo:
                if (hitorikakurenboAudio != null)
                {
                    if (hallwayAudio != null) hallwayAudio.Stop();
                    hitorikakurenboAudio.enabled = true;
                    hitorikakurenboAudio.Play();
                }
                break;
        }
    }
}