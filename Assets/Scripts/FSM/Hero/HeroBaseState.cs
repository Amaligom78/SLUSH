using UnityEngine;

public abstract class HeroBaseState : State
{
    protected HeroFSM stateMachine;

    public HeroBaseState(HeroFSM _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }
}
