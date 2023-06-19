using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro; // DELETE, USE FOR DEBUG

public class NavMeshAgentEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private TextMeshProUGUI debugText;
    [SerializeField] private Animator _anim;

    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        FollowPath();
        Animate();

    }

    private void FollowPath()
    {
        if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Move")) _agent.isStopped = true;
        else _agent.isStopped = false;
        _agent.SetDestination(_target.transform.position);
    }

    private void Animate()
    {

        if (_agent.velocity != Vector3.zero)
        {

            _anim.SetFloat("Vertical", _agent.velocity.y);
            _anim.SetFloat("Horizontal", _agent.velocity.x);
        }

        debugText.text =
               _agent.remainingDistance + "\n" +
               _agent.stoppingDistance;

        if (_agent.remainingDistance < _agent.stoppingDistance && _agent.remainingDistance < 20) 
        {
            print("Дистанция: "+_agent.remainingDistance);
            _anim.SetTrigger("Attack");
        }


        







    }
}
