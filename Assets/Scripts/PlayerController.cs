using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;

    private Rigidbody rb;
    private Animator animator;
    private Vector3 movement;
    private bool isGrounded;
    private bool jumpRequested;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        movement = new Vector3(moveX, 0f, moveZ);

        animator.SetFloat("Speed", movement.magnitude);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 move = movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        if (jumpRequested)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }
}

