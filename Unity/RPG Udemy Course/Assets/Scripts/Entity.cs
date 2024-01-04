using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Collision Info")]
    public Transform attackCheck;
    public float attackCheckRadius;
    [SerializeField] protected Transform groundTransform;
    [SerializeField] protected float groundDistance;
    [SerializeField] protected Transform wallTransform;
    [SerializeField] protected float wallDistance;
    [SerializeField] protected LayerMask groundLayerMask;

    [Header("Knockback Info")]
    [SerializeField] protected Vector2 knockBackDirection;
    [SerializeField] protected float knockBackDuration;
    protected bool isKnocked;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D entityRigidbody2D { get; private set; }
    public EntityFX fx { get; private set; }
    public SpriteRenderer sr { get; private set; }
    public CharacterStats characterStats { get; private set; }
    public CapsuleCollider2D cd { get; private set; }
    #endregion

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    protected virtual void Awake()
    { 
    }

    protected virtual void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        fx = GetComponent<EntityFX>();
        entityRigidbody2D = GetComponent<Rigidbody2D>();
        characterStats = GetComponent<CharacterStats>();
        cd = GetComponent<CapsuleCollider2D>();
    }

    protected virtual void Update()
    { 
    }

    public virtual IEnumerator HitKnockback() 
    { 
        isKnocked = true;

        entityRigidbody2D.velocity = new Vector2(knockBackDirection.x * -facingDir, knockBackDirection.y);

        yield return new WaitForSeconds(knockBackDuration);
        isKnocked = false;
    }

    public virtual void DamageEffect()
    {
        fx.StartCoroutine(fx.FlashFX());
        StartCoroutine(HitKnockback());
    }

    #region Collision
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundTransform.position, Vector2.down, groundDistance, groundLayerMask);

    public virtual bool IsWallDetected() => Physics2D.Raycast(wallTransform.position, Vector2.right * facingDir, wallDistance, groundLayerMask);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundTransform.position, new Vector3(groundTransform.position.x, groundTransform.position.y - groundDistance));
        Gizmos.DrawLine(wallTransform.position, new Vector3(wallTransform.position.x + wallDistance, wallTransform.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion

    #region Flip
    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float xVelocity)
    {
        if (xVelocity > 0 && !facingRight)
            Flip();
        else if (xVelocity < 0 && facingRight)
            Flip();
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

    public void MakeTransparent(bool isTransparent)
    {
        if (isTransparent)
            sr.color = Color.clear;
        else
            sr.color = Color.white;
    }

    public virtual void Die()
    { 
    
    }
}
