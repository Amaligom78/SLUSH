using UnityEditor.Animations;
using UnityEngine;

public class HeroFSM : StateMachine
{
    [field: SerializeField] public HeroInputReader inputReader { get; private set; }
    [field: SerializeField] public Targeter targeter { get; private set; }
    [field: SerializeField] public Animator heroAnimator { get; private set; }
    [field: SerializeField] public Transform cameraTransform { get; private set; }
    [field: SerializeField] public float moveSpeed { get; private set; } = 5f;
    [field: SerializeField] public float rotationSpeed { get; private set; } = 12f;

    public Rigidbody rb { get; private set; }


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SwitchState(new HeroMovementState(this));
    }
}
