using UnityEngine;

public class SingleShotTurret : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 2f;
    public float detectionRange = 10f;
    public LayerMask playerLayer;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        Collider[] hit = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);
        if (hit.Length > 0 && timer >= fireRate)
        {
            timer = 0f;

            GameObject bullet = BulletPoolManager.Instance.GetBullet(true); 
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
        }
    }
}
