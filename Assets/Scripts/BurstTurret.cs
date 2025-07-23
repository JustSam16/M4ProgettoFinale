using UnityEngine;

public class BurstTurret : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 1f;
    public int burstCount = 3;
    public float burstDelay = 0.1f;
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
            InvokeRepeating(nameof(Fire), 0f, burstDelay);
        }
    }

    private int shotsFired = 0;
    void Fire()
    {
        var bullet = BulletPool.Instance.GetBullet(false);
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
        }

        shotsFired++;
        if (shotsFired >= burstCount)
        {
            shotsFired = 0;
            CancelInvoke(nameof(Fire));
        }
    }
}
