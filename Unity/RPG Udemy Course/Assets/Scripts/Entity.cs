using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Collision Info")]
    public Transform attackCheck;
    public float attackCheckRadius = 1.2f;
    [SerializeField] protected Transform groundTransform;
    [SerializeField] protected float groundDistance = 1;
    [SerializeField] protected Transform wallTransform;
    [SerializeField] protected float wallDistance = .8f;
    [SerializeField] protected LayerMask groundLayerMask;

    public int knockbackDir { get; private set; }

    [Header("Knockback Info")]
    [SerializeField] protected Vector2 knockBackPower = new Vector2(7, 12);
    [SerializeField] protected Vector2 knockBackOffSet = new Vector2(.5f, 2);
    [SerializeField] protected float knockBackDuration = .07f;
    protected bool isKnocked;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D entityRigidbody2D { get; private set; }
    public SpriteRenderer sr { get; private set; }
    public CharacterStats characterStats { get; private set; }
    public CapsuleCollider2D cd { get; private set; }
    #endregion

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    public System.Action onFlipped;

    protected virtual void Awake()
    { 
    }

    protected virtual void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        entityRigidbody2D = GetComponent<Rigidbody2D>();
        characterStats = GetComponent<CharacterStats>();
        cd = GetComponent<CapsuleCollider2D>();
    }

    protected virtual void Update()
    { 
    }

    public virtual void SlowEntityBy(float slowPercentage, float slowDuration)
    { 

    }

    protected virtual void ReturnDefaultSpeed()
    {
        anim.speed = 1;
    }

    public void SetupKnockbackPower(Vector2 _knockbackpower) => knockBackPower = _knockbackpower;

    public virtual IEnumerator HitKnockback() 
    { 
        isKnocked = true;

        float xOffset = Random.Range(knockBackOffSet.x, knockBackOffSet.y);

        entityRigidbody2D.velocity = new Vector2((knockBackPower.x + xOffset) * knockbackDir, knockBackPower.y);

        yield return new WaitForSeconds(knockBackDuration);
        isKnocked = false;
        SetupZeroKnockbackPower();
    }

    protected virtual void SetupZeroKnockbackPower()
    { 
        
    }

    public virtual void DamageImpact() => StartCoroutine(HitKnockback());

    public virtual void SetupKnockbackDir(Transform _damageDirection)
    {
        if (_damageDirection.position.x > transform.position.x)
            knockbackDir = -1;
        else if (_damageDirection.position.x < transform.position.x)
            knockbackDir = 1;
    }

    #region Collision
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundTransform.position, Vector2.down, groundDistance, groundLayerMask);

    public virtual bool IsWallDetected() => Physics2D.Raycast(wallTransform.position, Vector2.right * facingDir, wallDistance, groundLayerMask);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundTransform.position, new Vector3(groundTransform.position.x, groundTransform.position.y - groundDistance));
        Gizmos.DrawLine(wallTransform.position, new Vector3(wallTransform.position.x + wallDistance * facingDir, wallTransform.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion

    #region Flip
    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);

        if (onFlipped != null)
            onFlipped();
    }

    public void FlipController(float xVelocity)
    {
        if (xVelocity > 0 && !facingRight)
            Flip();
        else if (xVelocity < 0 && facingRight)
            Flip();
    }

    public virtual void SetupDefaultFacingDir(int _direction)
    {
        facingDir = _direction;

        if (facingDir == -1)
            facingRight = false;
    }
    #endregion

    #region Velocity
    public void SetZeroVelocity()
    {
        if (isKnocked)
            return;

        entityRigidbody2D.velocity = Vector2.zero;
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        if (isKnocked)
            return;

        entityRigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
        FlipController(xVelocity);
    }
    #endregion

    public virtual void Die()
    { 
    
    }
}
