using UnityEngine;

public class LaserToggle : MonoBehaviour
{
    public float activeTime = 1f;
    public float inactiveTime = 2f;
    private Collider laserCollider;
    private Renderer laserRenderer;

    void Start()
    {
        laserCollider = GetComponent<Collider>();
        laserRenderer = GetComponent<Renderer>();
        StartCoroutine(ToggleLaser());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var hearts = other.GetComponent<PlayerHearts>();
            if (hearts != null)
            {
                hearts.TakeDamage();
            }
        }
    }

    System.Collections.IEnumerator ToggleLaser()
    {
        while (true)
        {
            
            laserRenderer.enabled = true;
            laserCollider.enabled = true;
            yield return new WaitForSeconds(activeTime);

            
            laserRenderer.enabled = false;
            laserCollider.enabled = false;
            yield return new WaitForSeconds(inactiveTime);
        }
    }
}

