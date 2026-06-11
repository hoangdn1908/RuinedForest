using System.Security.Cryptography;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private float attackTimer;
   public PlayerAttackState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {

    }

    public override void Enter()
    {
        SetAttackTimer();
        StopTheMovement();
        PlayAttackAnimation();
        ResetAttackInput();
    }

    public override void Exit()
    {
        playerController.playerCombat.ResetAttack();
    }

    public override void LogicUpdate()
    {
        CheckDeathState();
        AttackEnemy();
    }

    private void AttackEnemy() 
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            ExitAttack();
        }
    }

    public void SetAttackTimer() 
    {
        attackTimer = playerController.PlayerData.attackDuration;
    }

    private void PlayAttackAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Attack);
    }

    private void StopTheMovement() 
    {
        playerController.playerMovement.Stop();
    }

    private void ResetAttackInput() 
    {
        playerController.playerInput.ResetAttackInput();
    }
    private void ExitAttack() 
    {
        if (playerController.playerGroundDetector.IsGround())
        {
            if (playerController.playerInput.HasMoveInput())
            {
                playerStateMachine.ChangeState(playerController.playerRunState);
            }
            else
            {
                playerStateMachine.ChangeState(playerController.playerIdleState);
            }
        }
        else playerStateMachine.ChangeState(playerController.playerFallState);
    }

    private void CheckDeathState()
    {
        if (!playerController.playerHealth.IsAlive())
        {
            playerStateMachine.ChangeState(playerController.PlayerDeathState);
        }
    }
}
