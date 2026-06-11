using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private float currentHealth;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        SetCurrentHealth();
    }

    private void SetCurrentHealth() 
    {
        currentHealth = playerController.PlayerData.maxHealth;
    }
    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
    }

    public bool IsAlive() 
    {
        return currentHealth > 0;
    }
  
}
