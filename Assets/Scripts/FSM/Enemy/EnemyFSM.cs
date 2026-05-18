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
    [field: SerializeField] public float enemyMovementSpeed { get; private set; } = 3.5f;
    [field: SerializeField] public float enemyRotationSpeed { get; private set; } = 10f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        hero = GameObject.FindGameObjectWithTag("Hero");

        navAgent.updatePosition = false;
        navAgent.updateRotation = false;
        navAgent.speed = enemyMovementSpeed;
    }

    private void Start()
    {
        SwitchState(new EnemyIdleState(this));
    }

    private void LateUpdate()
    {
        if (navAgent != null)
        {
            navAgent.nextPosition = rb.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, heroChaseRange);
    }
}