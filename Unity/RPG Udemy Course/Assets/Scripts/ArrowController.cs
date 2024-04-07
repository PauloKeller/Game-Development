using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private string targetLayerName = "Player";
    [SerializeField] private int damage;
    [SerializeField] private float xVelocity;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool canMove;
    [SerializeField] private bool flipped;

    private CharacterStats myStats;

    private void Update()
    {
        if (!canMove)
            rb.velocity = new Vector2(xVelocity, rb.velocity.y);
    }

    public void SetupArrow(float speed, CharacterStats stats)
    { 
        xVelocity = speed;
        myStats = stats;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        {
            myStats.DoDamage(collision.GetComponent<CharacterStats>());
            StuckInto(collision);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            StuckInto(collision);
        }
    }

    private void StuckInto(Collider2D collision)
    {
        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponent<CapsuleCollider2D>().enabled = false;
        canMove = false;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.parent = collision.transform;

        Destroy(gameObject, Random.Range(5, 7));
    }

    public void FlipArrow()
    {
        if (flipped)
            return;

        xVelocity = xVelocity * -1;
        flipped = true;
        transform.Rotate(0, 180, 0);
        targetLayerName = "Enemy";
    }
}
