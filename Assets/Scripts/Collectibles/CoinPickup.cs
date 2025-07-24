using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameUIManager.Instance.CollectCoin();
            Destroy(gameObject);
        }
    }
}
