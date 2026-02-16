using UnityEngine;

// Enum voor verschillende types power-ups (Goud: Meerdere types)
public enum PowerUpType
{
    SpeedBoost,
    SlowDown
}

public class PowerUp : MonoBehaviour
{
    [Header("Power-Up Instellingen")]
    public PowerUpType type; // Kies hier welk type dit is (Zilver/Goud)

    [Header("Effect Waarden")]
    [Tooltip("Hoeveel keer sneller/langzamer? (bv. 2 = dubbel, 0.5 = helft)")]
    public float multiplier = 2f; 
    public float duration = 3f;

    [Header("Visuals (Goud)")]
    public Color speedColor = Color.yellow;
    public Color slowColor = Color.blue;

    // Brons eis: Variabele voor snelheid (hier gebruikt als standaardwaarde of referentie)
    private float speed = 5f; 

    private void Start()
    {
        UpdateVisuals();
    }

    // Update de kleur in de editor of bij start
    private void OnValidate()
    {
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            if (type == PowerUpType.SpeedBoost)
            {
                sr.color = speedColor;
                // Zorg dat de multiplier logisch is voor speed boost
                if (multiplier < 1f) multiplier = 2f; 
            }
            else if (type == PowerUpType.SlowDown)
            {
                sr.color = slowColor;
                // Zorg dat de multiplier logisch is voor slow down
                if (multiplier > 1f) multiplier = 0.5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Zoek het PlayerMovement script
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            
            if (player != null)
            {
                // Activeer de power-up op de speler
                player.ActivatePowerUp(multiplier, duration);
                
                // Verwijder de power-up uit de wereld
                Destroy(gameObject);
            }
        }
    }
}
