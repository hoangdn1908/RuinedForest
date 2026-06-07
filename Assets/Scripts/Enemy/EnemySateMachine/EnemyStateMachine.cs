using UnityEngine;

public class EnemyStateMachine
{
    public EnemyBaseState currentState {  get; private set; }

    public void InitializeState(EnemyBaseState state) 
    {
        currentState = state;
        currentState.Enter();
    }

    public void ChangeState(EnemyBaseState state) 
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}
