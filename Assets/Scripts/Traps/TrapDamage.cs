using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHearts health = other.GetComponent<PlayerHearts>();
            if (health != null)
            {
                health.TakeDamage(); 
            }
        }
    }
}
