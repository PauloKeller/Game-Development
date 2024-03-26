using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, string animationBoolName) : base(player, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.skillManager.dash.CloneOnDash();

        stateTimer = player.dashDuration;

        player.characterStats.MakeInvencible(true);
    }

    public override void Exit()
    {
        base.Exit();

        player.skillManager.dash.CloneOnArraival();
        player.SetVelocity(0, rb.velocity.y);
       
        player.characterStats.MakeInvencible(false);
    }

    public override void Update()
    {
        base.Update();

        if (!player.IsGroundDetected() && player.IsWallDetected())
            stateMachine.ChangeState(player.wallSlideState);

        player.SetVelocity(player.dashSpeed * player.dashDir, 0);

        if (stateTimer < 0)
            stateMachine.ChangeState(player.idleState);

        player.fx.CreateAfterImage();
    }
}
