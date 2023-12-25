using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animationBoolName;
    protected float xInput;
    protected float yInput;
    protected Rigidbody2D playerRigidbody2D;
    protected float stateTimer;
    protected bool triggerCalled;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animationBoolName) 
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animationBoolName = animationBoolName;
    }

    public virtual void Enter() 
    {
        player.anim.SetBool(animationBoolName, true);
        playerRigidbody2D = player.entityRigidbody2D;
        triggerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", playerRigidbody2D.velocity.y);
    }

    public virtual void Exit() 
    {
        player.anim.SetBool(animationBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    { 
        triggerCalled = true;
    }
}
