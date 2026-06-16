using System;
using System.Collections;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static Action<int> OnCoinSelected;
    [SerializeField] private Animator animator;
    [SerializeField] private float hitDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            OnCoinSelected?.Invoke(1);
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
