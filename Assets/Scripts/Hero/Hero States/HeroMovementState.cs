using UnityEngine;

public class HeroMovementState : HeroBaseState
{
    public HeroMovementState(HeroFSM _stateMachine) : base(_stateMachine) { }

    private Vector3 heroFacingDirection;
    private readonly int movementSpeed = Animator.StringToHash("MovementSpeed");

    void Start()
    {
        
    }

    public override void Enter()
    {
        stateMachine.inputReader.TargetEvent += OnTarget;
    }

    public override void Tick(float _deltaTime)
    {
        Vector2 movementValue = stateMachine.inputReader.MovementValue;

        Vector3 inputDirection = new Vector3(movementValue.x, 0f, movementValue.y);

        if (inputDirection.sqrMagnitude < 0.01f)
        {
            heroFacingDirection = Vector3.zero;
            return;
        }

        inputDirection.Normalize();

        Vector3 cameraForward = stateMachine.cameraTransform.forward;
        Vector3 cameraRight = stateMachine.cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        heroFacingDirection = cameraForward * inputDirection.z + cameraRight * inputDirection.x;
        heroFacingDirection.Normalize();
    }

    public override void FixedTick(float _fixedDeltaTime)
    {
        if (heroFacingDirection.sqrMagnitude < 0.01f)
        {
            stateMachine.heroAnimator.SetFloat(movementSpeed, 0, 0.1f, _fixedDeltaTime);
            return;
        }

        Vector3 newPosition = stateMachine.Rigidbody.position + heroFacingDirection * stateMachine.moveSpeed * _fixedDeltaTime;
        Quaternion targetRotation = Quaternion.LookRotation(heroFacingDirection);
        Quaternion newRotation = Quaternion.Slerp(stateMachine.Rigidbody.rotation, targetRotation, stateMachine.rotationSpeed * _fixedDeltaTime);

        stateMachine.Rigidbody.Move(newPosition, newRotation);
        stateMachine.heroAnimator.SetFloat(movementSpeed, 1, 0.1f, _fixedDeltaTime);
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
