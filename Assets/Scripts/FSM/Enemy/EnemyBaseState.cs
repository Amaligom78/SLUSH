using UnityEngine;

public abstract class EnemyBaseState : State
{

    protected EnemyFSM stateMachine;

    public EnemyBaseState(EnemyFSM _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }
    protected void Move(Vector3 movement, float fixedDeltaTime)
    {
        if (movement.sqrMagnitude < 0.01f) return;

        Vector3 newPosition =
            stateMachine.rb.position +
            movement * stateMachine.enemyMovementSpeed * fixedDeltaTime;

        stateMachine.rb.MovePosition(newPosition);
    }

    protected void FaceMovementDirection(Vector3 movement, float fixedDeltaTime)
    {
        if (movement.sqrMagnitude < 0.01f) return;

        Quaternion targetRotation = Quaternion.LookRotation(movement);
        Quaternion newRotation = Quaternion.Slerp(stateMachine.rb.rotation, targetRotation, stateMachine.enemyRotationSpeed * fixedDeltaTime);
        stateMachine.rb.MoveRotation(newRotation);
    }

    protected Vector3 GetMovementDirectionFromNavAgent()
    {
        Vector3 desiredVelocity = stateMachine.navAgent.desiredVelocity;
        desiredVelocity.y = 0f;

        if (desiredVelocity.sqrMagnitude < 0.01f)
        {
            return Vector3.zero;
        }

        return desiredVelocity.normalized;
    }

    public bool IsInChaseRange()
    {
        if(stateMachine.hero == null) return false;

        float heroDistanceSqr = (stateMachine.hero.transform.position - stateMachine.transform.position).sqrMagnitude;

        return heroDistanceSqr <= stateMachine.heroChaseRange * stateMachine.heroChaseRange;
    }
}
