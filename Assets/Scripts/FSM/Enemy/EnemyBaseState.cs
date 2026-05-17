using UnityEngine;

public abstract class EnemyBaseState : State
{

    protected EnemyFSM stateMachine;

    public EnemyBaseState(EnemyFSM _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }
}
