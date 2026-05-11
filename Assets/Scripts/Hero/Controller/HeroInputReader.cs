using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System;

public class HeroInputReader : MonoBehaviour, HeroControls.IHeroActions
{

    public Vector2 MovementValue {  get; private set; }
    public event Action JumpEvent;
    public event Action DodgeEvent;
    public event Action TargetEvent;
    private HeroControls heroControls;

    private void Awake()
    {
        heroControls = new HeroControls();
        heroControls.Hero.SetCallbacks(this);
        heroControls.Hero.Enable();
    }

    void Start()
    {

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        JumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        DodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnTarget(InputAction.CallbackContext context)
    {
        if (context.started || context.canceled)
        {
            TargetEvent?.Invoke();
        }
    }

    private void OnDestroy()
    {
        heroControls.Hero.Disable();
    }

}