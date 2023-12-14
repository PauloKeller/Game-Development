using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Collision Info")]
    [SerializeField] protected Transform groundTransform;
    [SerializeField] protected float groundDistance;
    [SerializeField] protected Transform wallTransform;
    [SerializeField] protected float wallDistance;
    [SerializeField] protected LayerMask groundLayerMask;

    #region Components
    public Animator animator { get; private set; }
    public Rigidbody2D entityRigidbody2D { get; private set; }
    #endregion

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    protected virtual void Awake()
    { 
    }

    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        entityRigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    { 
    }

    #region Collision
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundTransform.position, Vector2.down, groundDistance, groundLayerMask);

    public virtual bool IsWallDetected() => Physics2D.Raycast(wallTransform.position, Vector2.right * facingDir, wallDistance, groundLayerMask);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundTransform.position, new Vector3(groundTransform.position.x, groundTransform.position.y - groundDistance));
        Gizmos.DrawLine(wallTransform.position, new Vector3(wallTransform.position.x + wallDistance, wallTransform.position.y));
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
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        entityRigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
        FlipController(xVelocity);
    }
    #endregion
}
