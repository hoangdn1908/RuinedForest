using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float MoveInput {  get; private set; }
    public bool JumpPessed {  get; private set; }

    public void ReadInput() 
    {
        MoveInput = Input.GetAxisRaw("Horizontal");
        JumpPessed = Input.GetKeyDown(KeyCode.Space); 
    }

    public bool HasMoveInput() 
    {
        return MoveInput != 0;
    }

    public void ResetJumpInput() 
    {
        JumpPessed = false;
    }
}
