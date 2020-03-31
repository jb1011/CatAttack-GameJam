using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolHenry : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform[] patrolPoints;
    private int currentControlPointIndex = 0;

    public BoolVariable CanPatrol;

    private Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        MoveToNextPatrolPoint();
        CanPatrol.Value = true;
    }

    

    void Update()
    {
        if (CanPatrol.Value)
        {
            
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
            {

                MoveToNextPatrolPoint();
            }
        }

    }

    float timer = 3f;
    private void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            if (timer > 0)
            {
                _anim.SetBool("IsIdle", true);
                _anim.SetBool("IsWalking", false);
                timer -= Time.deltaTime;
                return;
            }
            _anim.SetBool("IsIdle", false);
            _anim.SetBool("IsWalking", true);
            navMeshAgent.destination = patrolPoints[currentControlPointIndex].position;
            currentControlPointIndex++;
            currentControlPointIndex %= patrolPoints.Length;
            timer = 3f;
        }
    }

    //IEnumerator WaitAMoment()
    //{
    //    _anim.SetBool("IsWalking", false);
    //    navMeshAgent.isStopped = true;
    //    yield return new WaitForSeconds(3f);
        
    //    MoveToNextPatrolPoint();
    //}
}
