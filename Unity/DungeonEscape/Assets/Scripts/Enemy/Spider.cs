using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField]
    private GameObject _acidPrefab;
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Update()
    {

    }

    public void Damage(int damageAmount)
    {
        if (isAlive)
        {
            Health -= 1;
            if (Health < 0)
            {
                isAlive = false;
                enemyAnimator.SetTrigger("Death");
                GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
                diamond.GetComponent<Diamond>().gems = gems;
            }
        }
    }

    public override void Movement() 
    { 
    
    }

    public void Attack()
    {
        Instantiate(_acidPrefab, transform.position, Quaternion.identity);
    }
}
