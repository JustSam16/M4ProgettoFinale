using UnityEngine;

public class FakeCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHearts playerHearts = other.GetComponent<PlayerHearts>();
            if (playerHearts != null)
            {
                playerHearts.TakeDamage(); 
            }

            Destroy(gameObject); 
        }
    }
}
