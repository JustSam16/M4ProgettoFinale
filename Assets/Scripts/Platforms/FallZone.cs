using UnityEngine;

public class FallZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameUIManager.Instance.ShowGameOver();
        }
    }
}
