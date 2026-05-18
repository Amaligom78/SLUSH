using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : StateMachine
{

    public Rigidbody rb { get; private set; }
    public NavMeshAgent navAgent {  get; private set; }
    [field: SerializeField] public Animator enemyAnimator { get; private set; }
    public GameObject hero { get; private set; }
    [field: SerializeField] public float heroChaseRange { get; private set; }
    [field: SerializeField] public float enemyMovementSpeed { get; private set; } = 20f;


    private void Start()
    {
        SwitchState(new EnemyIdleState(this));
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        hero = GameObject.FindGameObjectWithTag("Hero");

        navAgent.updatePosition = false;
        navAgent.updateRotation = false;
    }

    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, heroChaseRange);
    }
}