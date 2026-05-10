using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class StateMachine : MonoBehaviour
{

    private State currentState;

    private void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        currentState?.FixedTick(Time.fixedDeltaTime);
    }

    public void SwitchState(State _newState)
    {
        currentState?.Exit();
        currentState = _newState;
        currentState?.Enter();
    }
}
