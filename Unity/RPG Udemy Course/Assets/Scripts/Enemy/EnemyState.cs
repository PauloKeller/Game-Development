using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;
    protected Rigidbody2D rb;

    protected bool triggerCalled;
    protected float stateTimer;
    private string animationBoolName;

    public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName)
    {
        this.enemyBase = enemyBase;
        this.stateMachine = stateMachine;
        this.animationBoolName = animationBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemyBase.entityRigidbody2D;
        enemyBase.anim.SetBool(animationBoolName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animationBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
