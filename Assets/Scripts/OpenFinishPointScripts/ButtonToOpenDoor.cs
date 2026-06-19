using System;
using UnityEngine;

public class ButtonToOpenDoor : MonoBehaviour
{
    public static Action OnReachedButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            OnReachedButton?.Invoke();
        }
    }
}
