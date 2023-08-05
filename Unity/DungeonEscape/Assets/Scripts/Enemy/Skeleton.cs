using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage(int damageAmount)
    {
        if (isAlive)
        {
            Health -= damageAmount;
            enemyAnimator.SetTrigger("Hit");
            isHit = true;
            enemyAnimator.SetBool("InCombat", true);

            if (Health < 1)
            {
                isAlive = false;
                enemyAnimator.SetTrigger("Death");
                GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
                diamond.GetComponent<Diamond>().gems = gems;
            }
        }
    }
}
