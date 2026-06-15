using System.Collections;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float hitDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayHitAnimation();
            StartCoroutine(WaitAndHide());
        }
    }

    private void PlayHitAnimation() 
    {
        animator.SetBool("Hit", true);
    }

    private IEnumerator WaitAndHide() 
    {
        yield return new WaitForSeconds(hitDuration);
        gameObject.SetActive(false);
    }
}
