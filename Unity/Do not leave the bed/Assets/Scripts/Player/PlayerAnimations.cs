using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void MoveHorizontal(float move)
    {
        animator.SetFloat("Horizontal", move);
    }

    public void MoveVertical(float move)
    {
        animator.SetFloat("Vertical", move);
    }

    public void Speed(float move)
    {
        animator.SetFloat("Speed", move);
    }
}
