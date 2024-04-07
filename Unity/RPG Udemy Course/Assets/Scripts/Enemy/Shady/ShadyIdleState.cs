using System.Collections;
using UnityEngine;


public class ShadyIdleState : ShadyGroundedState
{
    public ShadyIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemyShady enemy) : base(enemyBase, stateMachine, animationBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);
    }
}
