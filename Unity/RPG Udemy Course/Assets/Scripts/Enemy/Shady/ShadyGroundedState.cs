using System.Collections;
using UnityEngine;

public class ShadyGroundedState : EnemyState
{
    protected Transform player;
    protected EnemyShady enemy;
    public ShadyGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemyShady enemy) : base(enemyBase, stateMachine, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < enemy.agroDistance)
            stateMachine.ChangeState(enemy.battleState);
    }
}