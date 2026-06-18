using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public  static Action<float, float> OnHealthChanged;
    public static Action OnPlayerDied;
    private float currentHealth;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        SetCurrentHealth();
        SetHealthChanged();
    }

    private void SetCurrentHealth() 
    {
        currentHealth = playerController.PlayerData.maxHealth;
    }

    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        SetHealthChanged();
        SetPlayerDied();
    }

    public bool IsAlive() 
    {
        return currentHealth > 0;
    }
  
    private void SetHealthChanged() 
    {
        OnHealthChanged?.Invoke(currentHealth, playerController.PlayerData.maxHealth);
    }

    private void SetPlayerDied() 
    {
        if (!IsAlive()) OnPlayerDied?.Invoke();
    }

}
