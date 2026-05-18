using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private readonly int enemyLocomotionSpeed = Animator.StringToHash("Locomotion");
    private readonly int enemySpeed = Animator.StringToHash("EnemySpeed");

    public EnemyChasingState(EnemyFSM _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.enemyAnimator.CrossFadeInFixedTime(enemyLocomotionSpeed, 0.01f);
    }

    public override void Tick(float _deltaTime)
    {
        MoveToHero();

        if (!IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            return;
        }

        stateMachine.enemyAnimator.SetFloat(enemySpeed, 1f, 0.1f, _deltaTime);
    }

    public override void FixedTick(float _fixedDeltaTime)
    {

    }

    public void MoveToHero()
    {
        stateMachine.navAgent.destination = stateMachine.hero.transform.position;
        //stateMachine.navAgent.desiredVelocity.normalized * stateMachine.enemyMovementSpeed
        //stateMachine.navAgent.velocity = 
    }

    public override void Exit()
    {
        stateMachine.navAgent.ResetPath();
        stateMachine.navAgent.velocity = Vector3.zero;
    }
}
