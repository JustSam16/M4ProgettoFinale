using UnityEngine;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector3 target;
    private Vector3 lastPosition;

    private List<Rigidbody> passengers = new List<Rigidbody>();

    void Start()
    {
        target = pointB.position;
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 movement = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime) - transform.position;
        transform.position += movement;

        
        foreach (Rigidbody rb in passengers)
        {
            rb.MovePosition(rb.position + movement);
        }

        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }

        lastPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if (rb != null && !passengers.Contains(rb))
            {
                passengers.Add(rb);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if (rb != null && passengers.Contains(rb))
            {
                passengers.Remove(rb);
            }
        }
    }
}
