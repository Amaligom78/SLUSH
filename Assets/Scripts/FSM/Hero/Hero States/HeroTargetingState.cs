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
        stateMachine.inputReader.TargetCanceledEvent += OnTarget;
        stateMachine.heroAnimator.Play(heroTargetingBlendTree);
    }

    public override void Tick(float _deltaTime)
    {
        if(stateMachine.inputReader.IsAttacking)
        {
            stateMachine.SwitchState(new HeroAttackingState(stateMachine, 0));
            return;
        }

        if (stateMachine.targeter.currentTarget == null)
        {
            stateMachine.SwitchState(new HeroMovementState(stateMachine));
            return;
        }

        movement = CalculateTargetingMovement();

        UpdateAnimator(_deltaTime);
    }

    public override void FixedTick(float _fixedDeltaTime)
    {
        if (stateMachine.targeter.currentTarget == null)
        {
            return;
        }

        Move(movement, _fixedDeltaTime);
        FaceTarget(_fixedDeltaTime);
    }

    private void UpdateAnimator(float deltaTime)
    {
        Vector2 movementValue = stateMachine.inputReader.MovementValue;

        float forwardValue = 0f;
        float rightValue = 0f;

        if (movementValue.y > 0f)
        {
            forwardValue = 1f;
        }
        else if (movementValue.y < 0f)
        {
            forwardValue = -1f;
        }

        if (movementValue.x > 0f)
        {
            rightValue = 1f;
        }
        else if (movementValue.x < 0f)
        {
            rightValue = -1f;
        }

        stateMachine.heroAnimator.SetFloat(targetingForward, forwardValue, 0.1f, deltaTime);
        stateMachine.heroAnimator.SetFloat(targetingRight, rightValue, 0.1f, deltaTime);
    }

    private void OnTarget()
    {
        stateMachine.SwitchState(new HeroMovementState(stateMachine));
    }

    public override void Exit()
    {
        stateMachine.inputReader.TargetCanceledEvent -= OnTarget;
        stateMachine.SyncThirdPersonCameraToCurrentView();
        stateMachine.targeter.StopTargeting();
    }
}