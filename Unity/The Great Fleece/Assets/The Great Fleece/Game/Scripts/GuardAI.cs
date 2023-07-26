using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    public bool coinTossed = false;
    public Vector3 coinPosition;

    private NavMeshAgent _agent;
    [SerializeField]
    private int currentTarget;
    private bool _reverse = false;
    private bool _targetReached = false;
    private Animator _animator;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[currentTarget] != null && !coinTossed)
        {
            _agent.SetDestination(wayPoints[currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

            if (distance < 1 && (currentTarget == 0 || currentTarget == wayPoints.Count - 1))
            {
                _animator.SetBool("Walk", false);
            }
            else
            {
                _animator.SetBool("Walk", true);
            }


            if ((distance < 1.0f) && !_targetReached)
            {
                if (wayPoints.Count < 2)
                {
                    return;
                }

                if (currentTarget == 0 || currentTarget == wayPoints.Count - 1 && wayPoints.Count > 1)
                {
                    _targetReached = true;
                    StartCoroutine(WaitBeforeMoving());
                }
                else
                {
                    if (_reverse)
                    {
                        currentTarget--;
                        if (currentTarget <= 0)
                        {
                            _reverse = false;
                            currentTarget = 0;
                        }
                    }
                    else
                    {
                        currentTarget++;
                    }
                }
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPosition);

            if (distance < 7f) {
                _animator.SetBool("Walk", false);
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        if (currentTarget == 0)
        {
            yield return new WaitForSeconds(2.0f);
        }
        else if (currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(2.0f);
        }

        if (_reverse)
        {
            currentTarget--;

            if (currentTarget <= 0)
            {
                _reverse = false;
                currentTarget = 0;
            }
        }
        else {
            currentTarget++;

            if (currentTarget == wayPoints.Count)
            {
                _reverse = true;
                currentTarget--;
            }
        }

        _targetReached = false;
    }
}
