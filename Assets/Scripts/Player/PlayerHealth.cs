using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    }
}
