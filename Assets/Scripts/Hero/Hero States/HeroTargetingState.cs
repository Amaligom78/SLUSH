using UnityEngine;

public class HeroTargetingState : HeroBaseState
{

    public HeroTargetingState(HeroFSM _stateMachine) : base(_stateMachine) { }

    private readonly int heroTargetingBlendTree = Animator.StringToHash("HeroTargetingBlendTree");
    public bool isTargeting { get; private set; } = false;

    public override void Enter()
    {
        stateMachine.inputReader.TargetEvent += OnTarget;
        stateMachine.heroAnimator.Play(heroTargetingBlendTree);
    }

    public override void Tick(float _deltaTime)
    {
        if(stateMachine.targeter.currentTarget  == null)
        {
            stateMachine.SwitchState(new HeroMovementState(stateMachine));
            return;
        }
    }

    public override void FixedTick(float _fixedDeltaTime)
    {
        if (stateMachine.targeter.currentTarget == null)
        {
            return;
        }

        FaceTarget();
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