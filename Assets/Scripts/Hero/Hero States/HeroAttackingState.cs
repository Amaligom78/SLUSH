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
            if(stateMachine.targeter.currentTarget != null)
            {
                stateMachine.SwitchState(new HeroAttackingState(stateMachine, 0));
            }
            else
            {
                stateMachine.SwitchState(new HeroMovementState(stateMachine));
            }
        }

            previousFrameTime = normalizeTime;
    }

    public override void FixedTick(float _fixedDeltaTime)
    {
        
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

    public override void Exit()
    {
        
    }
}