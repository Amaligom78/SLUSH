using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class HeroAttackingState : HeroBaseState
{
    private float previousFrameTime;
    private Attack_Data attackData;

    public HeroAttackingState(HeroFSM _stateMachine, int _attackIndex) : base(_stateMachine) 
    {
        attackData = stateMachine.attackDatas[_attackIndex];
    }

    public override void Enter()
    {
        previousFrameTime = 0f;
        stateMachine.heroAnimator.CrossFadeInFixedTime(attackData.animationName, attackData.transitionDuration);
    }

    public override void Tick(float _deltaTime)
    {
        float normalizeTime = GetNormilizedTime();

        if (normalizeTime < 1f)
        {
            if(stateMachine.inputReader.IsAttacking)
            {
                TryComboAttack(normalizeTime);
            }
        }
        else
        {
            ReturnToLocomotion();
        }

            previousFrameTime = normalizeTime;
    }

    public override void FixedTick(float _fixedDeltaTime)
    {
        float normalizedTime = GetNormilizedTime();

        if (stateMachine.targeter.currentTarget != null)
        {
            FaceTarget(_fixedDeltaTime);
        }

        if (normalizedTime >= attackData.movementStartTime && normalizedTime <= attackData.movementEndTime)
        {
            MoveForwardDuringAttack(attackData.forwardMovementSpeed, _fixedDeltaTime);
        }
    }

    private float GetNormilizedTime()
    {
        AnimatorStateInfo currentInfo =  stateMachine.heroAnimator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = stateMachine.heroAnimator.GetNextAnimatorStateInfo(0);

        if (stateMachine.heroAnimator.IsInTransition(0) && nextInfo.IsTag("Attack"))
        {
            return nextInfo.normalizedTime;
        }
        else if (!stateMachine.heroAnimator.IsInTransition(0) && currentInfo.IsTag("Attack"))
        {
            return currentInfo.normalizedTime;
        }
        else return 0f;
    }

    private void TryComboAttack(float normalizeTime)
    {
        if (attackData.comboStateIndex == -1) return;
        if (normalizeTime < attackData.comboAttackTime) return;

        stateMachine.SwitchState
        (
            new HeroAttackingState
            (
                stateMachine,
                attackData.comboStateIndex
            )
        );
    }

    private void ReturnToLocomotion()
    {
        if (stateMachine.inputReader.IsTargeting && stateMachine.targeter.currentTarget != null)
        {
            stateMachine.SwitchState(new HeroTargetingState(stateMachine));
            return;
        }

        stateMachine.SwitchState(new HeroMovementState(stateMachine));
    }

    public override void Exit()
    {
        
    }
}