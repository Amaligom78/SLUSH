using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System;

public class HeroMovement : MonoBehaviour, HeroControls.IHeroActions
{

    public Vector2 MovementValue {  get; private set; }
    public event Action JumpEvent;
    public event Action DodgeEvent;
    public event Action MoveEvent;

    private Rigidbody rb;
    private HeroControls heroControls;
    [SerializeField] Transform cameraTransform;
    [SerializeField] private float heroMoveSpeed = 5f;
    [SerializeField] private float heroRotSpeed = 12f;
    private Vector3 heroFacingDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        heroControls = new HeroControls();
        heroControls.Hero.SetCallbacks(this);
        heroControls.Hero.Enable();
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if(inputDirection.magnitude >= 0.1f)
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            cameraForward.y = 0f;
            cameraRight.y = 0f;

            cameraForward.Normalize();
            cameraRight.Normalize();

            heroFacingDirection = cameraForward * inputDirection.z + cameraRight * inputDirection.x;
        }
        else
        {
            heroFacingDirection = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (heroFacingDirection == Vector3.zero)
        {
            return;
        }

        Vector3 newPosition = rb.position + heroFacingDirection * heroMoveSpeed * Time.fixedDeltaTime;

        Quaternion targetRotation = Quaternion.LookRotation(heroFacingDirection);
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, heroRotSpeed * Time.fixedDeltaTime);

        rb.Move(newPosition, newRotation);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        JumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        DodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    private void OnDestroy()
    {
        heroControls.Hero.Disable();
    }

}
