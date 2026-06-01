using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int lifePoints = 100;
    

    [Header("UI")]
    public TextMeshProUGUI pointsText; 

    void Start()
    {

        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        lifePoints += amount;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        pointsText.text = lifePoints.ToString();

        if (lifePoints >= 180)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
