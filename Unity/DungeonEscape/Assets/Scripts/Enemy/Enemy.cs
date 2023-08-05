using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed = 3f;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA;
    [SerializeField]
    protected Transform pointB;
    [SerializeField]
    protected GameObject diamondPrefab;
   
    protected Vector3 currentTarget;
    protected Animator enemyAnimator;
    protected SpriteRenderer enemySprite;
    protected bool isHit = false;
    protected Player player;
    protected bool isAlive = true;
    public virtual void Init() 
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemySprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Start()
    {
        Init();
    }

    public virtual void Update() 
    {
        if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !enemyAnimator.GetBool("InCombat"))
        {
            return;
        }

        if (isAlive)
        {
            Movement();
        }   
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            enemySprite.flipX = true;
        }
        else
        {
            enemySprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            enemyAnimator.SetTrigger("Idle");

        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            enemyAnimator.SetTrigger("Idle");
            enemySprite.flipX = true;
        }

        if (!isHit) 
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if (distance > 2.0f) 
        {
            isHit = false;
            enemyAnimator.SetBool("InCombat", false);
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (enemyAnimator.GetBool("InCombat"))
        {
            if (direction.x > 0)
            {
                enemySprite.flipX = false;
            }
            else if (direction.x < 0)
            {
                enemySprite.flipX = true;
            }
        }
    }
}
