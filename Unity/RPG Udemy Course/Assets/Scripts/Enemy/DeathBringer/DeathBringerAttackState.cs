using System.Collections;
using System.ComponentModel.Design;
using UnityEngine;

public class DeathBringerAttackState : EnemyState
{
    private EnemyDeathBringer enemy;

    public DeathBringerAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemyDeathBringer enemy) : base(enemyBase, stateMachine, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.chanceToTeleport += 5;
    }

    public override void Exit()
    {
        base.Exit();

        enemy.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        enemy.SetZeroVelocity();

        if (triggerCalled)
        {
            if (enemy.CanTeleport())
            {
                stateMachine.ChangeState(enemy.teleportState);
            }
            else 
            { 
                stateMachine.ChangeState(enemy.battleState);
            }
        }
    }
}