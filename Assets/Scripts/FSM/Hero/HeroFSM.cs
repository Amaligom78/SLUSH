using UnityEngine;

public class HeroFSM : StateMachine
{
    [field: SerializeField] public HeroMovement InputReader {  get; private set; }

    void Start()
    {
        SwitchState(new HeroTestState(this));
    }
}
