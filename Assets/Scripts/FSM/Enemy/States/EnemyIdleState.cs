using UnityEngine;
using UnityEngine.Animations;

public class EnemyIdleState : EnemyBaseState
{

    private readonly int enemyLocomotionSpeed = Animator.StringToHash("Locomotion");
    private readonly int enemySpeed = Animator.StringToHash("EnemySpeed");

    public EnemyIdleState(EnemyFSM _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.enemyAnimator.CrossFadeInFixedTime(enemyLocomotionSpeed, 0.01f);
    }

    public override void Tick(float _deltaTime)
    {

    }

    public override void FixedTick(float _fixedDeltaTime)
    {
        if (IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
            return;
        }

        stateMachine.enemyAnimator.SetFloat(enemySpeed, 0f, 0.1f, _fixedDeltaTime);
    }

    public override void Exit()
    {

    }
}
