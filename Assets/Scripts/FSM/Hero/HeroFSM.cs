using UnityEditor.Animations;
using UnityEngine;
using Unity.Cinemachine;

public class HeroFSM : StateMachine
{
    [field: SerializeField] public HeroInputReader inputReader { get; private set; }
    [field: SerializeField] public Targeter targeter { get; private set; }
    [field: SerializeField] public Animator heroAnimator { get; private set; }
    [field: SerializeField] public Transform cameraTransform { get; private set; }
    [field: SerializeField] public CinemachineCamera thirdPersonCamera { get; private set; }
    [field: SerializeField] public Camera mainCamera { get; private set; }

    private CinemachineOrbitalFollow thirdPersonOrbitalFollow;
    [field: SerializeField] public float moveSpeed { get; private set; } = 5f;
    [field: SerializeField] public float rotationSpeed { get; private set; } = 12f;

    public Rigidbody rb { get; private set; }


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (thirdPersonCamera != null)
        {
            thirdPersonOrbitalFollow = thirdPersonCamera.GetComponent<CinemachineOrbitalFollow>();
        }
    }

    private void Start()
    {
        SwitchState(new HeroMovementState(this));
    }

    public void SyncThirdPersonCameraToCurrentView()
    {
        if (thirdPersonOrbitalFollow == null) return;
        if (mainCamera == null) return;

        thirdPersonOrbitalFollow.ForceCameraPosition(mainCamera.transform.position, mainCamera.transform.rotation);
    }
}
