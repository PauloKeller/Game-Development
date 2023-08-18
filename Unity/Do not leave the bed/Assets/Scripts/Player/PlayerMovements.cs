using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;

    Light2D flashlight;
    Quaternion rightDirection = Quaternion.Euler(0, 0, 0);
    Quaternion leftDirection = Quaternion.Euler(0, 0, 180f);
    Quaternion upDirection = Quaternion.Euler(0, 0, 90f);
    Quaternion downDirection = Quaternion.Euler(0, 0, -90f);
    Player player;
    PlayerAnimations playerAnimations;
    Vector2 movement;
    Rigidbody2D palyerRigidbody2D;

    void Start()
    {
        flashlight = GetComponentInChildren<Light2D>();
        player = GetComponent<Player>();
        playerAnimations = GetComponent<PlayerAnimations>();
        palyerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player.IsAlive) 
        {
            MovePlayer();
            ChangeFlashlightDirection();
        }
    }

    void MovePlayer() 
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        playerAnimations.MoveHorizontal(movement.x);
        playerAnimations.MoveVertical(movement.y);
        playerAnimations.Speed(movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (player.IsAlive) 
        {
            palyerRigidbody2D.MovePosition(palyerRigidbody2D.position + movement * moveSpeed * Time.deltaTime);
        }
    }

    void ChangeFlashlightDirection() {
        if (movement.x > 0)
        {
            flashlight.transform.rotation = rightDirection;
        }
        else if (movement.x < 0)
        {
            flashlight.transform.rotation = leftDirection;
        }
        else if (movement.y > 0)
        {
            flashlight.transform.rotation = upDirection;
        }
        else if (movement.y < 0)
        {
            flashlight.transform.rotation = downDirection;
        }
    }
}
