using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private float currentHealth;

    public void SetCurrentHealth(float health) 
    {
        currentHealth = health;
    }

    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    public void Die() 
    {
        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController == null && playerController.PlayerDeathState == null) return;
        playerController.playerStateMachine.ChangeState(playerController.PlayerDeathState);
    }

    public void DisablePlayer() 
    {
    
    }
}
