using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    float _moveSpeed = 10f;
    [SerializeField]
    float _steerSpeed = 180f;
    [SerializeField]
    float _slowSpeed = 5f;
    [SerializeField]
    float _boostSpeed = 15f;


    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * -_steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            _moveSpeed = _boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
       _moveSpeed = _slowSpeed;
    }
}
