using System;
using UnityEngine;

public class FinishedPointController : MonoBehaviour
{
    public static Action OnReachedPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            OnReachedPoint?.Invoke();
        }
    }
}
