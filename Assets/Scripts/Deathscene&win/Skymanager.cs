using UnityEngine;

public class Skymanager : MonoBehaviour
{
    public float skysSpeed = 1f; 

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skysSpeed);
    }
}
