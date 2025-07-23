using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float range = 10f;
    private float fireTimer;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        fireTimer = fireRate;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= range)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0f)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                fireTimer = fireRate;
            }
        }
    }
}
