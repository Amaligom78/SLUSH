using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class StateMachine : MonoBehaviour
{

    private State currentState;

    void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }

    public void SwitchState(State _newState)
    {
        currentState?.Exit();
        currentState = _newState;
        currentState?.Enter();
    }
}
