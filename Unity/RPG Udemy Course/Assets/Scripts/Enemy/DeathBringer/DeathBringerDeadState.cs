using System.Collections;
using UnityEngine;

public class DeathBringerDeadState : EnemyState
{
    private EnemyDeathBringer enemy;
    public DeathBringerDeadState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemyDeathBringer enemy) : base(enemyBase, stateMachine, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.anim.SetBool(enemy.lastAnimBoolName, true);
        enemy.anim.speed = 0;
        enemy.cd.enabled = false;

        stateTimer = .15f;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer > 0)
            rb.velocity = new Vector2(0, 10);
    }
}