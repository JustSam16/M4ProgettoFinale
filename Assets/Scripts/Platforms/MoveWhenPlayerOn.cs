using UnityEngine;
using System.Collections.Generic;

public class MoveWhenPlayerOn : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;

    private bool playerOn = false;
    private bool hasReached = false;

    private List<Rigidbody> passengers = new List<Rigidbody>();
    private Vector3 lastPosition;

    void Start()
    {
        transform.position = startPoint.position;
        lastPosition = transform.position;
    }

    void Update()
    {
        if (playerOn && !hasReached)
        {
            Vector3 movement = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime) - transform.position;
            transform.position += movement;

            foreach (Rigidbody rb in passengers)
            {
                rb.MovePosition(rb.position + movement);
            }

            if (Vector3.Distance(transform.position, endPoint.position) < 0.05f)
            {
                hasReached = true;
            }
        }

        lastPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOn = true;

            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if (rb != null && !passengers.Contains(rb))
                passengers.Add(rb);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if (rb != null && passengers.Contains(rb))
                passengers.Remove(rb);
        }
    }
}

