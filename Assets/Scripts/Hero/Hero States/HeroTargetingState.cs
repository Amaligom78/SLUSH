using UnityEngine;

public class HeroTargetingState : HeroBaseState
{

    public HeroTargetingState(HeroFSM _stateMachine) : base(_stateMachine) { }
    public bool isTargeting { get; private set; } = false;

    public override void Enter()
    {
        stateMachine.inputReader.TargetEvent += OnTarget;
        Debug.Log("Targeting");
    }

    public override void FixedTick(float _fixedDeltaTime)
    {
        
    }

    public override void Tick(float _deltaTime)
    {
        
    }

    private void OnTarget()
    {
        stateMachine.SwitchState(new HeroMovementState(stateMachine));
    }

    public override void Exit()
    {
        stateMachine.inputReader.TargetEvent -= OnTarget;
        Debug.Log("Targeting Cancelled");
    }
}