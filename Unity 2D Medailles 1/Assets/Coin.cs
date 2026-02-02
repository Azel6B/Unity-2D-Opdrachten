using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    [SerializeField] private AudioClip collectSound; 

    private CoinSpawner mySpawner; // Referentie naar de spawner die deze munt heeft gemaakt

    public void SetSpawner(CoinSpawner spawner)
    {
        mySpawner = spawner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // Vertel de spawner dat deze munt is opgepakt
            if (mySpawner != null)
            {
                mySpawner.OnCoinCollected();
            }

            GameManager.Instance.AddScore(coinValue);
            Destroy(gameObject);
        }
    }
}
