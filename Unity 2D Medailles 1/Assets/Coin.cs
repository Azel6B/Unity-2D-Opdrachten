using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    [SerializeField] private AudioClip collectSound;

    private CoinSpawner mySpawner;

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

            if (mySpawner != null)
            {
                mySpawner.OnCoinCollected();
            }

            GameManager.Instance.AddScore(coinValue);
            GameManager.Instance.CheckWinCondition();  

            Destroy(gameObject);
        }
    }
}