using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] private Image playerHealthBarUI;

    private void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateHealthBarUI;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateHealthBarUI;
    }
    private void UpdateHealthBarUI(float currentHealth, float maxHealth) 
    {
        playerHealthBarUI.fillAmount = currentHealth / maxHealth;
    }
}
