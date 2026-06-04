using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private readonly int stateIdHash = Animator.StringToHash("StateId");

    public void SetStateAnimation(PlayerAnimationStates states) 
    {
        animator.SetInteger(stateIdHash, (int) states);
        animator.Play(states.ToString());
    }
}
