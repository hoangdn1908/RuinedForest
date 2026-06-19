using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnEnable()
    {
        ButtonToOpenDoor.OnReachedButton += HandleOpenDoor;
    }

    private void OnDisable()
    {
        ButtonToOpenDoor.OnReachedButton -= HandleOpenDoor;
    }

    private void HandleOpenDoor() 
    {
        animator.SetBool("isOpening", true);
    }

    private void DisableDoor() 
    {
        gameObject.SetActive(false);
    }
}
