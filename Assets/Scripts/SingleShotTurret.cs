using UnityEngine;

public class SingleShotTurret : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 2f;
    public float detectionRange = 10f;

    private float fireTimer;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > detectionRange) return;

        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            Fire();
        }
    }

    void Fire()
    {
        var bullet = BulletPool.Instance.GetBullet(false);
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
        }
    }
}
