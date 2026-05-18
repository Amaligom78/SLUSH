using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private readonly int enemyLocomotionSpeed = Animator.StringToHash("Locomotion");
    private readonly int enemySpeed = Animator.StringToHash("EnemySpeed");

    private Vector3 movement;

    public EnemyChasingState(EnemyFSM _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.enemyAnimator.CrossFadeInFixedTime(enemyLocomotionSpeed, 0.01f);
    }

    public override void Tick(float _deltaTime)
    {
        if (!IsInChaseRange())
        {

            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            return;
        }

        stateMachine.navAgent.SetDestination(stateMachine.hero.transform.position);

        movement = GetMovementDirectionFromNavAgent();

        float animatorSpeed = movement.sqrMagnitude > 0.01f ? 1f : 0f;

        stateMachine.enemyAnimator.SetFloat(enemySpeed, animatorSpeed, 0.1f, _deltaTime);
    }

    public override void FixedTick(float _fixedDeltaTime)
    {
        Move(movement, _fixedDeltaTime);
        FaceMovementDirection(movement, _fixedDeltaTime);
    }

    public override void Exit()
    {
        stateMachine.navAgent.ResetPath();
        movement = Vector3.zero;
        stateMachine.enemyAnimator.SetFloat(enemySpeed, 0f);
    }
}
