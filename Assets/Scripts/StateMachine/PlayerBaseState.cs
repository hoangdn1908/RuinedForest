using UnityEngine;

public abstract class PlayerBaseState 
{
    protected PlayerController playerController;
    protected PlayerStateMachine playerStateMachine;

    public PlayerBaseState(PlayerController playerController, PlayerStateMachine playerStateMachine) 
    {
        this.playerController = playerController;
        this.playerStateMachine = playerStateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void LogicUpdate() { }
    public virtual void PhysicUpdate() { }

    public virtual void HandleInput() { }
}
