using UnityEngine;

public class HeroTestState : HeroBaseState
{

    public HeroTestState(HeroFSM _stateMachine) : base(_stateMachine)
    {
        
    }

    public override void Enter()
    {
        
    }

    public override void Tick(float _deltaTime)
    {
        Vector3 movement = new Vector3();
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0f;
        movement.z = stateMachine.InputReader.MovementValue.y;
        stateMachine.transform.Translate(movement * _deltaTime);
        Debug.Log(stateMachine.InputReader.MovementValue);
    }

    public override void Exit()
    {
        
    }
}
