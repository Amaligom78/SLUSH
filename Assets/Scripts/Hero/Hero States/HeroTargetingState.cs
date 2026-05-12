using UnityEngine;

public class HeroTargetingState : HeroBaseState
{

    public HeroTargetingState(HeroFSM _stateMachine) : base(_stateMachine) { }

    private readonly int heroTargetingBlendTree = Animator.StringToHash("HeroTargetingBlendTree");
    private readonly int targetingForward = Animator.StringToHash("TargetingForward");
    private readonly int targetingRight = Animator.StringToHash("TargetingRight");
    private Vector3 movement;

    public override void Enter()
    {
        stateMachine.inputReader.TargetEvent += OnTarget;
        stateMachine.heroAnimator.Play(heroTargetingBlendTree);
    }


    public override void Tick(float _deltaTime)
    {
        if (stateMachine.targeter.currentTarget == null)
        {
            stateMachine.SwitchState(new HeroMovementState(stateMachine));
            return;
        }

        movement = CalculateMovement();

        Vector2 movementValue = stateMachine.inputReader.MovementValue;

        //stateMachine.heroAnimator.SetFloat(targetingForward, movementValue.y, 0.1f, _deltaTime);
        //stateMachine.heroAnimator.SetFloat(targetingRight, movementValue.x, 0.1f, _deltaTime);
    }

    public override void FixedTick(float _fixedDeltaTime)
    {
        if (stateMachine.targeter.currentTarget == null) return;

        Move(movement, _fixedDeltaTime);
        FaceTarget(_fixedDeltaTime);
    }

    private void OnTarget()
    {
        stateMachine.SwitchState(new HeroMovementState(stateMachine));
    }

    public override void Exit()
    {
        stateMachine.inputReader.TargetEvent -= OnTarget;
        stateMachine.targeter.ClearTarget();
    }
}