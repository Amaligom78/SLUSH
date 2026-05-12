using UnityEngine;

public abstract class HeroBaseState : State
{
    protected HeroFSM stateMachine;

    public HeroBaseState(HeroFSM _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }

    protected void FaceTarget()
    {
        if (stateMachine.targeter.currentTarget == null) return;

        Vector3 targetPOS = stateMachine.targeter.currentTarget.transform.position - stateMachine.rb.position;
        targetPOS.y = 0;
        Quaternion targetRot = Quaternion.LookRotation(targetPOS);
        stateMachine.rb.MoveRotation(targetRot);
    }
}
