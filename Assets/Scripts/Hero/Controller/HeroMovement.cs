using UnityEngine;
using UnityEngine.EventSystems;

public class HeroMovement : MonoBehaviour
{

    private Rigidbody rb;
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
        
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
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
}
