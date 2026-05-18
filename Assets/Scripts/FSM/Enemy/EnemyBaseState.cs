using UnityEngine;

public abstract class EnemyBaseState : State
{

    protected EnemyFSM stateMachine;

    public EnemyBaseState(EnemyFSM _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }

    public void Move(float _fixedDeltaTime)
    {
        stateMachine.rb.MovePosition(stateMachine.rb.transform.forward * stateMachine.enemyMovementSpeed * _fixedDeltaTime);
    }

    public bool IsInChaseRange()
    {
        float heroDistanceSqr = (stateMachine.hero.transform.position - stateMachine.transform.position).sqrMagnitude;
        return heroDistanceSqr <= stateMachine.heroChaseRange * stateMachine.heroChaseRange;
    }
}
