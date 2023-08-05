using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rigidbody;
    private bool _resetJump = false;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprite;
    private bool _grounded = false;
    private bool _isAlive = true;

    public int Health { get; set; }
    public int diamonds = 0;

    [SerializeField]
    private float _jumpForce = 6.0f;
    [SerializeField]
    private float _speed = 2.5f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); 
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }

    void Update()
    {
        Movement();

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (CrossPlatformInputManager.GetButtonDown("AButton") && IsGrounded())
            {
                Attack();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && IsGrounded())
            {
                Attack();
            }
        }
    }

    void Attack() 
    {
        _playerAnimation.Attack();
    }

    void Movement()
    {
        float move;
        
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            move = Input.GetAxis("Horizontal");
        }
        else
        {
            move = CrossPlatformInputManager.GetAxis("Horizontal");
        }

        _grounded = IsGrounded();

        if (move > 0)
        {
            Flip(false);
        }
        else if (move < 0)
        {
            Flip(true);
        }

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
            if (CrossPlatformInputManager.GetButtonDown("BButton") && _grounded)
            {
                Jump();
            }
        } else {
            if (Input.GetKeyDown(KeyCode.Space) && _grounded)
            {
                Jump();
            }
        }
       
         _rigidbody.velocity = new Vector2(move * _speed, _rigidbody.velocity.y);
        _playerAnimation.Move(move);
    }

    void Jump() 
    {
        _playerAnimation.Jump(true);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        StartCoroutine(ResetJumpRoutine());
    }

    void Flip(bool facingLeft) 
    {
        _playerSprite.flipX = facingLeft;
        _swordArcSprite.flipX = facingLeft;
        _swordArcSprite.flipY = facingLeft;

        Vector3 newPosition = _swordArcSprite.transform.localPosition;
        newPosition.x = facingLeft ? -1.01f : 1.01f;
        _swordArcSprite.transform.localPosition = newPosition;
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);

        if (hitInfo.collider != null)
        {
            if (!_resetJump)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }

        return false;
    }

    IEnumerator ResetJumpRoutine() {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage(int damageAmount)
    {
        if (_isAlive)
        {
            Health -= 1;
            UIManager.Instance.UpdateHealth(Health);

            if (Health < 1)
            {
                _isAlive = false;
                _playerAnimation.Death();
            }
        }
    }
}
