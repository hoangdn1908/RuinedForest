using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   public float MoveInput {  get; private set; }

    public void ReadInput() 
    {
        MoveInput = Input.GetAxisRaw("Horizontal");
    }

    public bool HasMoveInput() 
    {
        return MoveInput != 0;
    }
}
