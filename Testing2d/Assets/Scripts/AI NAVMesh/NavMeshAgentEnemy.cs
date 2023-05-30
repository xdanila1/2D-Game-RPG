using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private NavMeshAgent _agent;
    [SerializeField] private Animator _anim;
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
        _agent.SetDestination(_target.transform.position);
        if (_agent.velocity != Vector3.zero)
        {

            _anim.SetFloat("Vertical", _agent.velocity.y);
            _anim.SetFloat("Horizontal", _agent.velocity.x);
        }
    }
}
