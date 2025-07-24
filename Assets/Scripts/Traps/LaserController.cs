using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{
    public float activeDuration = 2f;
    public float inactiveDuration = 2f;

    private Renderer rend;
    private Collider col;

    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        StartCoroutine(LaserCycle());
    }

    IEnumerator LaserCycle()
    {
        while (true)
        {
            
            rend.enabled = true;
            col.enabled = true;
            yield return new WaitForSeconds(activeDuration);

            
            rend.enabled = false;
            col.enabled = false;
            yield return new WaitForSeconds(inactiveDuration);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && col.enabled)
        {
            Debug.Log("Laser attivo! Player colpito.");
           
        }
    }
}
