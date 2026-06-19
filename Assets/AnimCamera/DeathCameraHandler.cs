using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCameraHandler : MonoBehaviour
{
    public void OnDeathAnimationEnd()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
