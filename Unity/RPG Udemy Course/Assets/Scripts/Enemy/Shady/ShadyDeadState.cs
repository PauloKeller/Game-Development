using System.Collections;
using UnityEngine;
public class ShadyDeadState : EnemyState
{
    private EnemyShady enemy;

    public ShadyDeadState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemyShady enemy) : base(enemyBase, stateMachine, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            enemy.SelfDestroy();
        }
    }
}