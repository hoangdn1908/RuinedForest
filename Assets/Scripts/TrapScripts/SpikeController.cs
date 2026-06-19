using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerHealth playerHealth = collision.GetComponentInParent<PlayerHealth>();
            if (playerHealth == null) 
            {
                return;
            }
            playerHealth.TakeDamage(100);
        }
    }
}
