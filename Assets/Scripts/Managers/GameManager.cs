using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject door;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UnlockDoor()
    {
        if (door != null)
        {
            door.SetActive(false);
        }
    }
}
