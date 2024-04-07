﻿using System.Collections;
using UnityEngine;

public class ShadyStunnedState : EnemyState
{
    private EnemyShady enemy;
    public ShadyStunnedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemyShady enemy) : base(enemyBase, stateMachine, animationBoolName)
    {
        this.enemy = enemy;
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

        enemy.fx.Invoke("CancelColorChange", 0);
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.idleState);
    }
}