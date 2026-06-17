using System;
using System.Collections;
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
        SetHealthChanged();
    }

    private void Update()
    {
        Die();
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
    }

    public bool IsAlive() 
    {
        return currentHealth > 0;
    }
  
    private void SetHealthChanged() 
    {
        OnHealthChanged?.Invoke(currentHealth, playerController.PlayerData.maxHealth);
    }

    private void Die() 
    {
        if (!IsAlive())
        {
            GameManager.Instance.ChangeGameState(GameStates.Lose);
        }
    }
}
