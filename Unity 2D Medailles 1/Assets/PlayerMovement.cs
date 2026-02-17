using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 12f;
    private float defaultSpeed;

    [Header("Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private float horizontalInput;
    private bool isGrounded;

    void Start()
    {
        defaultSpeed = speed;
        body = GetComponent<Rigidbody2D>();

        // Ensure the character doesn't tip over
        body.freezeRotation = true;
    }

    void Update()
    {
        // A and D movement
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Ground check logic
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Jump with W (only if touching the ground)
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }

        CheckForFlipping();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // We only set the X velocity and keep the current Y velocity (so gravity works!)
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
    }

    private void CheckForFlipping()
    {
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, 1f);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, 1f);
        }
    }

    // Week 5: PowerUp Logic preserved
    public void ActivatePowerUp(float speedMultiplier, float duration)
    {
        StartCoroutine(PowerUpRoutine(speedMultiplier, duration));
    }

    private IEnumerator PowerUpRoutine(float multiplier, float duration)
    {
        speed *= multiplier;
        Debug.Log($"PowerUp Active! Speed is now: {speed}");

        yield return new WaitForSeconds(duration);

        speed = defaultSpeed;
        Debug.Log("PowerUp ended. Speed reset.");
    }
}
