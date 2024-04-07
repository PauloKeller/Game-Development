using System.Collections;
using UnityEngine;

public class DeathBringerTeleportState : EnemyState
{
    private EnemyDeathBringer enemy;

    public DeathBringerTeleportState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemyDeathBringer enemy) : base(enemyBase, stateMachine, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.characterStats.MakeInvencible(true);
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            if (enemy.CanDoSpellCast())
            {
                stateMachine.ChangeState(enemy.spellCastState);
            }
            else 
            { 
                stateMachine.ChangeState(enemy.battleState);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();

        enemy.characterStats.MakeInvencible(false);
    }
}