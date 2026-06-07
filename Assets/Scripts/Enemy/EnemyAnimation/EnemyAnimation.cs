using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private readonly int stateIdHash = Animator.StringToHash("StateId");

    public void SetStateAnimation(EnemyAnimationStates states)
    {
        animator.SetInteger(stateIdHash, (int)states);
        animator.Play(states.ToString());
    }
}
