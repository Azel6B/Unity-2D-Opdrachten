using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int amountToSpawn = 5;
    [SerializeField] private float spawnRadius = 2f;

    [Header("Reward Settings (Gold)")]
    [SerializeField] private AudioClip rewardSound; // Geluid als alle 5 muntjes op zijn

    private int coinsRemaining;
    private bool hasSpawned = false;

    // Wordt aangeroepen door Unity als iets de trigger raakt
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check of de speler door de trigger loopt en we nog niet gespawned hebben (Zilver)
        if (other.CompareTag("Player") && !hasSpawned)
        {
            SpawnCoins();
            hasSpawned = true;
            Destroy(gameObject, 1f); // Verwijder de spawner na een korte delay
        }
    }

    private void SpawnCoins()
    {
        if (coinPrefab == null) return;

        coinsRemaining = amountToSpawn;

        // Brons: Spawn 5 coins via een loop op 5 posities
        for (int i = 0; i < amountToSpawn; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);

            GameObject spawnedCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            
            // Zilver/Goud logica: Koppel de munt aan deze spawner
            Coin coinScript = spawnedCoin.GetComponent<Coin>();
            if (coinScript != null)
            {
                coinScript.SetSpawner(this);
            }
        }
        
        Debug.Log($"Week 4: {amountToSpawn} muntjes gespawned via trigger!");
    }

    // Wordt aangeroepen door Coin.cs (Goud)
    public void OnCoinCollected()
    {
        coinsRemaining--;

        if (coinsRemaining <= 0)
        {
            PlayRewardSound();
        }
    }

    private void PlayRewardSound()
    {
        if (rewardSound != null)
        {
            AudioSource.PlayClipAtPoint(rewardSound, transform.position);
            Debug.Log("Goud behaald! Alle muntjes verzameld.");
        }
    }
}
