using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DetectionHenry : MonoBehaviour
{
    private Animator _anim;

    public BoolVariable CanPatrol;

    [SerializeField]
    private Transform _target;

    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private float closeDistance = 1f;

    [SerializeField]
    private AudioSource _angrySound;

    [SerializeField]
    private AudioSource _manHumming;

    public BoolVariable IsHitting;

    [SerializeField]
    private Animator _animUI;

    [SerializeField]
    private AudioSource _AudioUI;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _angrySound.volume = 0;
        _animUI.SetBool("IsOver", false);

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && IsHitting.Value)
        {
            _navMeshAgent.isStopped = false;
            
            CanPatrol.Value = false;

            _navMeshAgent.destination = _target.transform.position;

            _anim.SetBool("IsIdle", false);
            _anim.SetBool("IsWalking", true);
            _anim.SetBool("IsYelling", false);
            _navMeshAgent.isStopped = false;

            Vector3 offset = _target.transform.position - transform.position;
            float sqrLen = offset.sqrMagnitude;
            _manHumming.volume = 1;
            _angrySound.volume = 0;

            if (sqrLen < closeDistance * closeDistance)
            {
                //_navMeshAgent.isStopped = true;
                StartCoroutine("GotCaught");

            }
        }
    }

    IEnumerator GotCaught()
    {
        _angrySound.volume = 1;
        _manHumming.volume = 0;
        _navMeshAgent.isStopped = true;
        _anim.SetBool("IsYelling", true);
        _anim.SetBool("IsIdle", false);
        _anim.SetBool("IsWalking", false);
        _animUI.SetBool("IsOver", true);
        _AudioUI.Play();
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerExit(Collider other)
    {
        CanPatrol.Value = true;

    }
}
