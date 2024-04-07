using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStunnedState : EnemyState
{
    private EnemySlime enemy;

    public SlimeStunnedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemySlime _enemy) : base(enemyBase, stateMachine, animationBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.fx.InvokeRepeating("RedColorBlink", 0, .1f);

        stateTimer = enemy.stunDuration;

        rb.velocity = new Vector2(-enemy.facingDir * enemy.stunDirection.x, enemy.stunDirection.y);
    }

    public override void Exit()
    {
        base.Exit();

        enemy.characterStats.MakeInvencible(false);
    }

    public override void Update()
    {
        base.Update();

        if (rb.velocity.y < .1f && enemy.IsGroundDetected())
        {
            enemy.characterStats.MakeInvencible(true);
            enemy.anim.SetTrigger("StunFold");
            enemy.fx.Invoke("CancelColorChange", 0);
        }

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.idleState);
    }
}
