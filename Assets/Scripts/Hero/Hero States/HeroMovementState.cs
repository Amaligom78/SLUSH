using UnityEngine;

public class HeroMovementState : HeroBaseState
{
    public HeroMovementState(HeroFSM _stateMachine) : base(_stateMachine) { }

    private Vector3 movement;
    private readonly int heroMovementBlendTree = Animator.StringToHash("HeroMovementBlendTree");
    private readonly int movementSpeed = Animator.StringToHash("MovementSpeed");

    void Start()
    {
        
    }

    public override void Enter()
    {
        stateMachine.inputReader.TargetEvent += OnTarget;
        stateMachine.heroAnimator.Play(heroMovementBlendTree);
    }

    public override void Tick(float _deltaTime)
    {
        movement = CalculateMovement();
    }

    public override void FixedTick(float _fixedDeltaTime)
    {
        Move(movement, _fixedDeltaTime);
        FaceMovementDirection(movement, _fixedDeltaTime);

        float animatorSpeed = movement.sqrMagnitude > 0.01f ? 1f : 0f;

        stateMachine.heroAnimator.SetFloat(movementSpeed, animatorSpeed, 0.1f, _fixedDeltaTime);
    }

    private void OnTarget()
    {
        if (!stateMachine.targeter.SelectTarget()) return;

        stateMachine.SwitchState(new HeroTargetingState(stateMachine));
    }

    public override void Exit()
    {
        stateMachine.inputReader.TargetEvent -= OnTarget;
    }
}
