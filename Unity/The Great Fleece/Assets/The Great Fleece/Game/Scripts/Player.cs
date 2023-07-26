using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public GameObject coinPrefab;
    public AudioClip coinSoundEffect;

    private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 _target;
    private bool _coinTossed = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _agent.SetDestination(hitInfo.point);
                _animator.SetBool("Walk", true);
                _target = hitInfo.point;
            }
        }

        float distance = Vector3.Distance(transform.position, _target);
        if (distance < 1.0f)
        {
            _animator.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(1) && !_coinTossed)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _animator.SetTrigger("Throw");
                Instantiate(coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSoundEffect, Camera.main.transform.position);
                _coinTossed = true;
                SendAIToCoinSpot(hitInfo.point);
            }
        }
    }

    void SendAIToCoinSpot(Vector3 coinPosition)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach (var guard in guards)
        {
            NavMeshAgent guardAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI guardAI = guard.GetComponent<GuardAI>();
            Animator guardAnimator = guard.GetComponent<Animator>();

            guardAnimator.SetBool("Walk", true);
            guardAI.coinTossed = _coinTossed;
            guardAI.coinPosition = coinPosition;
            guardAgent.SetDestination(coinPosition);
        }
    }
}
