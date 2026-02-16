using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private float defaultSpeed;

    private Rigidbody2D body;
    private Vector2 axisMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultSpeed = speed; // Sla de originele snelheid op
        body = GetComponent<Rigidbody2D>();
    }

    // Week 5: Functie om de snelheid tijdelijk aan te passen
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
