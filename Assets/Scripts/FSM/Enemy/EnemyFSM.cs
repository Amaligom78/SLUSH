using UnityEngine;

public class EnemyFSM : StateMachine
{

    [field: SerializeField] public Animator enemyAnimator { get; private set; }

    private void Start()
    {
        SwitchState(new EnemyIdleState(this));
    }
}