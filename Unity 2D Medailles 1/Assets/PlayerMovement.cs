using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private float defaultSpeed;

<<<<<<< Updated upstream
=======
    [Header("Double Jump Settings")]
    [SerializeField] private int maxJumps = 2;  // Hoeveel keer kan springen
    private int jumpsRemaining;                 // Huidige sprongen over

    [Header("Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

>>>>>>> Stashed changes
    private Rigidbody2D body;
    private Vector2 axisMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultSpeed = speed; // Sla de originele snelheid op
        body = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
    }

    // Week 5: Functie om de snelheid tijdelijk aan te passen
=======
        body.freezeRotation = true;
        jumpsRemaining = maxJumps;  // Begin met alle sprongen
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Ground check logic
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Reset jumps wanneer op de grond
        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
        }

        // Double jump logic (W of Space)
        if (Input.GetKeyDown(KeyCode.W) && jumpsRemaining > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
            jumpsRemaining--;
            Debug.Log($"Sprong gebruikt! Nog {jumpsRemaining} sprong(en) over");
        }

        CheckForFlipping();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
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

    // PowerUp Logic
>>>>>>> Stashed changes
    public void ActivatePowerUp(float speedMultiplier, float duration)
    {
        StartCoroutine(PowerUpRoutine(speedMultiplier, duration));
    }

    private System.Collections.IEnumerator PowerUpRoutine(float multiplier, float duration)
    {
        speed *= multiplier; // Verhoog of verlaag de snelheid
        Debug.Log($"PowerUp Active! Speed is now: {speed}");

        yield return new WaitForSeconds(duration); // Wacht voor de duur van de power-up

        speed = defaultSpeed; // Zet de snelheid terug naar normaal
        Debug.Log("PowerUp ended. Speed reset.");
    }
<<<<<<< Updated upstream

    // Update is called once per frame
    void Update()
    {
       axisMovement.x = Input.GetAxisRaw("Horizontal");
       axisMovement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();

    }
    private void Move()
    {
        body.linearVelocity = axisMovement.normalized * speed;
        CheckForFlipping();
    }
    private void CheckForFlipping()
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;

        if(movingLeft)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y);
        }

        if(movingRight)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y);
        }
    }
}
=======
}
>>>>>>> Stashed changes
