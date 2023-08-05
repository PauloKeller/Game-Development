using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;


    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null && _canDamage) 
        {
            hit.Damage(1);
            _canDamage = false;
            StartCoroutine(ResetCanDamageCoroutine());
        }
    }

    IEnumerator ResetCanDamageCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
