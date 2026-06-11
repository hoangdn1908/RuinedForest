using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private float currentHealth;
    [SerializeField] private PlayerController playerController;

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
        if (playerController == null && playerController.PlayerDeathState == null) return;
        playerController.playerStateMachine.ChangeState(playerController.PlayerDeathState);
    }

    public void DisablePlayer() 
    {
        playerController.enabled = false;
    }
}
