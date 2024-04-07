﻿using System.Collections;
using UnityEngine;

public class DeathBringerIdleState : EnemyState
{
    private EnemyDeathBringer enemy;
    private Transform player;
    public DeathBringerIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemyDeathBringer enemy) : base(enemyBase, stateMachine, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Vector2.Distance(player.transform.position, enemy.transform.position) < 7)
        {
            enemy.bossFightBegun = true;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            stateMachine.ChangeState(enemy.teleportState);
        }

        if (stateTimer < 0 && enemy.bossFightBegun)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}