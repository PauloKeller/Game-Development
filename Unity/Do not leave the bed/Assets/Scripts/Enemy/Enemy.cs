using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5.0f;

    Vector3 directionToPlayer;
    bool spottedByPlayer = false;
    Transform playerTransform;

    void Start()
    {
        
    }

    void Update()
    {
        if (spottedByPlayer)
        {
            MoveIntoPlayerDirection();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Flashlight")
        {
            playerTransform = other.transform.parent.transform;
            // directionToPlayer = other.transform.parent.position - transform.position;
            spottedByPlayer = true;
        }

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.SufferDamage(10);
        }
    }

    void MoveIntoPlayerDirection() 
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        Vector3 moveDirection = directionToPlayer.normalized;
        if (distanceToPlayer > 1f)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
