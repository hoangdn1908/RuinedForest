using System;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public  static Action<float, float> OnHealthChanged;
    private float currentHealth;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        SetCurrentHealth();
        OnHealthChanged?.Invoke(currentHealth, playerController.PlayerData.maxHealth);
    }

    private void SetCurrentHealth() 
    {
        currentHealth = playerController.PlayerData.maxHealth;
    }
    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        OnHealthChanged?.Invoke(currentHealth, playerController.PlayerData.maxHealth);
    }

    public bool IsAlive() 
    {
        return currentHealth > 0;
    }
  
}
