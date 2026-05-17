using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System;

public class HeroInputReader : MonoBehaviour, HeroControls.IHeroActions
{

    public Vector2 MovementValue {  get; private set; }
    public bool IsAttacking { get; private set; }
    public bool IsTargeting { get; private set; }
    public event Action JumpEvent;
    public event Action DodgeEvent;
    public event Action TargetStartedEvent;
    public event Action TargetCanceledEvent;
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
        if (context.started)
        {
            IsTargeting = true;
            TargetStartedEvent?.Invoke();
            return;
        }

        if (context.canceled)
        {
            IsTargeting = false;
            TargetCanceledEvent?.Invoke();
            return;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            IsAttacking = true;
        }
        else if(context.canceled)
        {
            IsAttacking = false;
        }
    }

    private void OnDestroy()
    {
        heroControls.Hero.Disable();
    }
}