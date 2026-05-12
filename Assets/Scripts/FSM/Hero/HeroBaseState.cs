using UnityEngine;

public abstract class HeroBaseState : State
{
    protected HeroFSM stateMachine;

    public HeroBaseState(HeroFSM _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }

    protected Vector3 CalculateMovement()
    {
        Vector2 movementValue = stateMachine.inputReader.MovementValue;

        Vector3 inputDirection = new Vector3(movementValue.x, 0f, movementValue.y);

        if (inputDirection.sqrMagnitude < 0.01f)
        {
            return Vector3.zero;
        }

        inputDirection.Normalize();

        Vector3 cameraForward = stateMachine.cameraTransform.forward;
        Vector3 cameraRight = stateMachine.cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = cameraForward * inputDirection.z + cameraRight * inputDirection.x;

        return movement.normalized;
    }

    protected void Move(Vector3 movement, float fixedDeltaTime)
    {
        if (movement.sqrMagnitude < 0.01f) return;

        Vector3 newPosition = stateMachine.rb.position + movement * stateMachine.moveSpeed * fixedDeltaTime;

        stateMachine.rb.MovePosition(newPosition);
    }

    protected void FaceMovementDirection(Vector3 movement, float fixedDeltaTime)
    {
        if (movement.sqrMagnitude < 0.01f) return;

        Quaternion targetRotation = Quaternion.LookRotation(movement);
        Quaternion newRotation = Quaternion.Slerp(stateMachine.rb.rotation, targetRotation, stateMachine.rotationSpeed * fixedDeltaTime);

        stateMachine.rb.MoveRotation(newRotation);
    }

    protected void FaceTarget(float fixedDeltaTime)
    {
        if (stateMachine.targeter.currentTarget == null) return;

        Vector3 targetPosition = stateMachine.targeter.currentTarget.transform.position;
        Vector3 directionToTarget = targetPosition - stateMachine.rb.position;

        directionToTarget.y = 0f;

        if (directionToTarget.sqrMagnitude < 0.01f) return;

        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        Quaternion newRotation = Quaternion.Slerp(stateMachine.rb.rotation, targetRotation, stateMachine.rotationSpeed * fixedDeltaTime);

        stateMachine.rb.MoveRotation(newRotation);
    }
}
