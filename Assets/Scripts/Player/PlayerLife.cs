using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Image fillLife;
    private PlayerController playerController;

    private float maxLife;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        maxLife = playerController.vida;
    }

    void Update()
    {
        fillLife.fillAmount = playerController.vida / maxLife;
    }
}
