using UnityEngine;

public class CheeseGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameUIManager.Instance.ShowVictory();
            gameObject.SetActive(false); 
        }
    }
}
