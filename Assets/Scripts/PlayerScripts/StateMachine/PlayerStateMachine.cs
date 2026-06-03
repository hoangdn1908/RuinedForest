using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerBaseState currentState {  get; private set; }

    public void InitializeState(PlayerBaseState state) 
    {
        currentState = state;
        currentState.Enter();
    }

    public void ChangeState(PlayerBaseState state) 
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}
