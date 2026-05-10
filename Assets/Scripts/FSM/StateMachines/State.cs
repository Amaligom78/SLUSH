using UnityEngine;

public abstract class State
{
    public abstract void Enter();
    public abstract void Tick(float _deltaTime);
    public abstract void FixedTick(float _fixedDeltaTime);
    public abstract void Exit();
}
