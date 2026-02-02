using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isFacingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (moveInput != Vector2.zero)
        {
            string directionLabel = GetDirectionLabel(moveInput);
            Debug.Log($"Player is moving: {directionLabel}");
        }

        if (moveInput.x > 0 && !isFacingRight) Flip();
        else if (moveInput.x < 0 && isFacingRight) Flip();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }

    private string GetDirectionLabel(Vector2 input)
    {
        string horizontal = input.x > 0 ? "Right (D)" : (input.x < 0 ? "Left (A)" : "");
        string vertical = input.y > 0 ? "Up (W)" : (input.y < 0 ? "Down (S)" : "");

        if (horizontal != "" && vertical != "") return $"{vertical} and {horizontal}";
        return horizontal + vertical;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Debug.Log("Player flipped direction. Facing Right: " + isFacingRight);

        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
