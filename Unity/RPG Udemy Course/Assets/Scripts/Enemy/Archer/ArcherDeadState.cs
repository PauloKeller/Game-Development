using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDeadState : EnemyState
{
    private EnemyArcher enemy;

    public ArcherDeadState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemyArcher enemy) : base(enemyBase, stateMachine, animationBoolName)
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