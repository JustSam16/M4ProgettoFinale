using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 2f;
    private bool isTriggered = false;
    private float timer = 0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isTriggered && collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }

    void Update()
    {
        if (isTriggered)
        {
            timer += Time.deltaTime;
            if (timer >= fallDelay)
            {
                rb.isKinematic = false; 
                Destroy(gameObject, 3f); 
            }
        }
    }
}
