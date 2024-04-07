using System.Collections;
using UnityEngine;

public class DeathBringerSpellCastState : EnemyState
{
    private EnemyDeathBringer enemy;
    private int amountOfSpells;
    private float spellCooldown;
    private float spellTimer;

    public DeathBringerSpellCastState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemyDeathBringer enemy) : base(enemyBase, stateMachine, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        amountOfSpells = enemy.amountOfSpells;
        spellTimer = .5f;
    }

    public override void Update()
    {
        base.Update();

        spellTimer -= Time.deltaTime;

        if (CanCast())
        {
            enemy.CastSpell();
        }

        if (amountOfSpells <= 0)
        {
            stateMachine.ChangeState(enemy.teleportState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        enemy.lastTimeCast = Time.time;
    }

    private bool CanCast()
    {
        if (amountOfSpells > 0 && spellTimer < 0)
        {
            amountOfSpells--;
            spellTimer = enemy.spellCooldown;
            return true;
        }

        return false;
    }
}