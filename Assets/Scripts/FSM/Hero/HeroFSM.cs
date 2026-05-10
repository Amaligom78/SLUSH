using UnityEditor.Animations;
using UnityEngine;

public class HeroFSM : StateMachine
{
    [field: SerializeField] public HeroInputReader InputReader { get; private set; }
    [field: SerializeField] public Animator heroAnimator { get; private set; }
    [field: SerializeField] public Transform CameraTransform { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 12f;

    public Rigidbody Rigidbody { get; private set; }


    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SwitchState(new HeroMovement(this));
    }
}
