using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private float damage = 10f;

    private void Awake()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            Debug.Log(damage);
        }
    }
}
